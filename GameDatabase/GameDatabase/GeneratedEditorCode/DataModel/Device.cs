//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
	public partial class Device
	{
		partial void OnDataDeserialized(DeviceSerializable serializable, Database database);
		partial void OnDataSerialized(ref DeviceSerializable serializable);


		public Device(DeviceSerializable serializable, Database database)
		{
			Id = new ItemId<Device>(serializable.Id, serializable.FileName);
			类型 = serializable.DeviceClass;
			主动能耗 = new NumericValue<float>(serializable.EnergyConsumption, 0f, 1E+09f);
			被动能耗 = new NumericValue<float>(serializable.PassiveEnergyConsumption, 0f, 1E+09f);
			效果强度 = new NumericValue<float>(serializable.Power, 0f, 1000f);
			射程 = new NumericValue<float>(serializable.Range, 0f, 1000f);
			大小 = new NumericValue<float>(serializable.Size, 0f, 1000f);
			冷却 = new NumericValue<float>(serializable.Cooldown, 0f, 1000f);
			持续时间 = new NumericValue<float>(serializable.Lifetime, 0f, 1000f);
			效果偏移 = serializable.Offset;
			控制类型 = serializable.ActivationType;
			颜色 = Helpers.ColorFromString(serializable.Color);
			音效 = serializable.Sound;
			引用效果 = serializable.EffectPrefab;
			引用对象 = serializable.ObjectPrefab;
			按钮贴图 = serializable.ControlButtonIcon;

			OnDataDeserialized(serializable, database);
		}

		public void Save(DeviceSerializable serializable)
		{
			serializable.DeviceClass = 类型;
			serializable.EnergyConsumption = 主动能耗.Value;
			serializable.PassiveEnergyConsumption = 被动能耗.Value;
			serializable.Power = 效果强度.Value;
			serializable.Range = 射程.Value;
			serializable.Size = 大小.Value;
			serializable.Cooldown = 冷却.Value;
			serializable.Lifetime = 持续时间.Value;
			serializable.Offset = 效果偏移;
			serializable.ActivationType = 控制类型;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.Sound = 音效;
			serializable.EffectPrefab = 引用效果;
			serializable.ObjectPrefab = 引用对象;
			serializable.ControlButtonIcon = 按钮贴图;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Device> Id;

		public DeviceClass 类型;
		public NumericValue<float> 主动能耗 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 被动能耗 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 效果强度 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 射程 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 冷却 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 持续时间 = new NumericValue<float>(0, 0f, 1000f);
		public Vector2 效果偏移;
		public ActivationType 控制类型;
		public System.Drawing.Color 颜色;
		public string 音效;
		public string 引用效果;
		public string 引用对象;
		public string 按钮贴图;

		public static Device DefaultValue { get; private set; }
	}
}
