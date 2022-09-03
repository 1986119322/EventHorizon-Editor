using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using EditorDatabase.Storage;
using GameDatabase.Properties;
using Newtonsoft.Json;

namespace GameDatabase
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs eventArgs)
        {
            OpenDatabase(Directory.GetCurrentDirectory());
        }

        private void OpenDatabase(string path)
        {
            try
            {
                DatabaseTreeView.Nodes.Clear();
                _lastDatabasePath = path;
                _database = new Database(new DatabaseStorage(path));
                BuildFilesTree(path, DatabaseTreeView.Nodes);
            }
            catch (DatabaseException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + e.StackTrace);
            }
        }

        private void BuildFilesTree(string path, TreeNodeCollection nodeCollection)
        {
            try
            {
                foreach (var directory in Directory.EnumerateDirectories(path))
                {
                    var name = directory.Substring(directory.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase) + 1);
                    var node = nodeCollection.Add(directory, name);
                    BuildFilesTree(directory, node.Nodes);
                }

                foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                    nodeCollection.Add(file, Helpers.FileName(file));
            }
            catch (Exception e)
            {
                MessageBox.Show("错误: " + e.Message);
            }
        }

        private void DatabaseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowItemInfo(e.Node.Name);
        }

        private void ShowItemInfo(string path)
        {
            try
            {
                ItemTypeText.Text = @"-";
                _selectedItem = new SerializableItem();
                EditButton.Enabled = false;

                if (Directory.Exists(path))
                {
                    ItemTypeText.Text = @"目录";
                    structDataView1.Data = GetDirectoryInfo(path);
                    return;
                }

                var data = File.ReadAllText(path);
                var name = Helpers.FileName(path);
                var item = JsonConvert.DeserializeObject<SerializableItem>(data);
                item.FileName = name;
                if ((ItemType)item.ItemType == ItemType.未定义)
                    return;

                ItemTypeText.Text = ((ItemType)item.ItemType).ToString();
                _selectedItem = item;

                structDataView1.Database = _database;
                structDataView1.Data = GetItem();

                EditButton.Enabled = true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        private struct DirectoryInfoData
        {
            public NumericValue<int> Json数量;//FilesCount
            public ItemType 文件类型;//ItemTypes
            public NumericValue<int> 最后使用的Id;//LastItemId
            public NumericValue<int> 首个未使用的Id;//FirstUnusedId
        }

        private DirectoryInfoData GetDirectoryInfo(string path)
        {
            DirectoryInfoData data = new DirectoryInfoData
            {
                Json数量 = new NumericValue<int>(0, 0, int.MaxValue),
                文件类型 = ItemType.未定义,
                最后使用的Id = new NumericValue<int>(0, 0, int.MaxValue),
                首个未使用的Id = new NumericValue<int>(0, 0, int.MaxValue),
            };

            try
            {
                var ids = new List<bool> { true };
                foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                {
                    var text = File.ReadAllText(file);
                    var item = JsonConvert.DeserializeObject<SerializableItem>(text);

                    data.Json数量.Value++;

                    if (item.ItemType == ItemType.未定义)
                        continue;

                    if (ids.Count <= item.Id)
                        ids.AddRange(Enumerable.Repeat(false, item.Id - ids.Count + 1));
                    ids[item.Id] = true;

                    if (data.文件类型 == ItemType.未定义)
                        data.文件类型 = item.ItemType;
                }

                data.最后使用的Id.Value = ids.Count - 1;
                var index = ids.IndexOf(false);
                data.首个未使用的Id.Value = index > 0 ? index : ids.Count;
            }
            catch (Exception e)
            {
            }

            return data;
        }

        private void DatabaseTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditButton_Click(sender, e);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var item = GetItem();
            if (item == null)
                return;

            switch (_selectedItem.ItemType)
            {
                case ItemType.组件:
                    new ComponentEditorDialog(_database, (Component)item).ShowDialog();
                    break;
                case ItemType.僚机:
                case ItemType.飞船:
                    new ShipEditorDialog(_database, item, _selectedItem.FileName).ShowDialog();
                    break;
                default:
                    new EditorDialog(_database, item, _selectedItem.FileName).ShowDialog();
                    break;
            }
        }

        private object GetItem()
        {
            return _database.GetItem(_selectedItem.ItemType, _selectedItem.Id);
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenDatabase(folderBrowserDialog1.SelectedPath);
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _database.Save(new DatabaseStorage(folderBrowserDialog1.SelectedPath));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_lastDatabasePath))
                _database.Save(new DatabaseStorage(_lastDatabasePath));
        }

        private void createModMenuItem_Click(object sender, EventArgs e)
        {
            CreateMod();
        }

        private void createCEModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("警告：创建社区版 mod 意味着编译不加密的 mod。\n此外，某些社区版构建可能不支持加载此 mod。", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                CreateMod(false);
        }

        private void CreateMod(bool encrypt = true)
        {
            if (string.IsNullOrWhiteSpace(_lastDatabasePath))
                return;

            try
            {
                if (!ModBuilder.TryReadSignature(_lastDatabasePath, out var name, out var guid))
                {
                    var dialog = new NameForm();
                    if (dialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.Name))
                        return;

                    name = dialog.Name;
                    guid = Guid.NewGuid().ToString();

                    File.WriteAllText(Path.Combine(_lastDatabasePath, ModBuilder.SignatureFileName), name + '\n' + guid );
                }

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                _database.Save(new DatabaseStorage(_lastDatabasePath));
                var builder = ModBuilder.Create(_lastDatabasePath);
                builder.Build((FileStream)saveFileDialog.OpenFile(), encrypt);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private SerializableItem _selectedItem;
        private Database _database;
        private string _lastDatabasePath;

        private void reloadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDatabase(_lastDatabasePath);
        }

        private void changeMaxListLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm("输入新的最大列表长度", Settings.Default.MaxListLen.ToString());
            try
            {
                if (input.ShowDialog() == DialogResult.OK)
                    Settings.Default.MaxListLen = int.Parse(input.Result);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
