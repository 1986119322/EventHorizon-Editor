﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Ionic.Zlib;

namespace GameDatabase
{
    public sealed class ModBuilder
    {
        public enum FileType : byte
        {
            None = 0,
            Data = 1,
            Image = 2,
            Localization = 3,
            WaveAudio = 4,
        }

        public static ModBuilder Create(string path)
        {
            string name, guid;
            return TryReadSignature(path, out name, out guid) ? new ModBuilder(path, name, guid) : null;
        }

        public static bool TryReadSignature(string path, out string name, out string guid)
        {
            name = string.Empty;
            guid = string.Empty;

            try
            {
                var id = new DirectoryInfo(path).GetFiles(SignatureFileName).FirstOrDefault();
                if (id == null)
                    return false;

                var data = File.ReadAllLines(id.FullName);
                if (data.Length < 2)
                    return false;

                name = data[0];
                guid = data[1];

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(guid))
                    return false;

                if (guid.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Build(FileStream stream, bool encrypt)
        {
            try
            {
                var rawdata = SerializeData().ToArray();
                var data = ZlibStream.CompressBuffer(rawdata.ToArray());

                var size = (uint)data.Length;
                byte checksumm = 0;
                uint w = 0x12345678 ^ size;
                uint z = 0x87654321 ^ size;
                for (int i = 0; i < size; ++i)
                {
                    checksumm += data[i];
                    if (encrypt)
                    {
                        data[i] = (byte)(data[i] ^ (byte)random(ref w, ref z));
                    }
                }

                stream.Write(data, 0, data.Length);
                stream.WriteByte((byte)(encrypt ? checksumm ^ (byte)random(ref w, ref z) : checksumm));
            }
            finally
            {
                stream.Close();
            }
        }

        private IEnumerable<byte> SerializeData()
        {
            foreach (var value in Serialize(_name))
                yield return value;
            foreach (var value in Serialize(_id))
                yield return value;

            foreach (var file in new DirectoryInfo(_datapath).EnumerateFiles("*", SearchOption.AllDirectories))
            {
                var ext = file.Extension.ToLower();
                if (ext == ".json")
                {
                    yield return (byte)FileType.Data;
                    foreach (var value in SerializeTextFile(file.FullName))
                        yield return value;
                }
                else if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    yield return (byte)FileType.Image;
                    foreach (var value in Serialize(file.Name))
                        yield return value;
                    foreach (var value in SerializeBinaryFile(file.FullName))
                        yield return value;
                }
                else if (ext == ".wav")
                {
                    yield return (byte)FileType.WaveAudio;
                    foreach (var value in Serialize(Path.GetFileNameWithoutExtension(file.Name)))
                        yield return value;
                    foreach (var value in SerializeBinaryFile(file.FullName))
                        yield return value;
                }
                else if (ext == ".xml")
                {
                    yield return (byte)FileType.Localization;
                    foreach (var value in Serialize(Path.GetFileNameWithoutExtension(file.Name)))
                        yield return value;
                    foreach (var value in SerializeTextFile(file.FullName))
                        yield return value;
                }
                else
                {
                    continue;
                }
            }

            yield return (byte)FileType.None;
        }

        private IEnumerable<byte> SerializeBinaryFile(string name)
        {
            var fileData = File.ReadAllBytes(name);
            foreach (var value in BitConverter.GetBytes(fileData.Length))
                yield return value;
            foreach (var value in fileData)
                yield return value;
        }

        private IEnumerable<byte> SerializeTextFile(string name)
        {
            var fileData = File.ReadAllText(name);
            return Serialize(fileData);
        }

        private static IEnumerable<byte> Serialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                foreach (var value in BitConverter.GetBytes(0))
                    yield return value;
                yield break;
            }

            var bytes = System.Text.Encoding.UTF8.GetBytes(data);

            foreach (var value in BitConverter.GetBytes(bytes.Length))
                yield return value;
            foreach (var value in System.Text.Encoding.UTF8.GetBytes(data))
                yield return value;
        }

        private static uint random(ref uint w, ref uint z)
        {
            z = 36969 * (z & 65535) + (z >> 16);
            w = 18000 * (w & 65535) + (w >> 16);
            return (z << 16) + w;  /* 32-bit result */
        }

        private ModBuilder(string datapath, string name, string id)
        {
            _datapath = datapath;
            _name = name;
            _id = id;
        }

        private readonly string _datapath;
        private readonly string _name;
        private readonly string _id;

        public const string SignatureFileName = "id";
    }
}
