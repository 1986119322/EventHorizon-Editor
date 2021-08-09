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
	public partial class DroneBay
	{
		partial void OnDataDeserialized(DroneBaySerializable serializable, Database database);
		partial void OnDataSerialized(ref DroneBaySerializable serializable);


		public DroneBay(DroneBaySerializable serializable, Database database)
		{
			Id = new ItemId<DroneBay>(serializable.Id, serializable.FileName);
			释放能耗 = new NumericValue<float>(serializable.EnergyConsumption, 0f, 1E+09f);
			被动能耗 = new NumericValue<float>(serializable.PassiveEnergyConsumption, 0f, 1E+09f);
			索敌范围 = new NumericValue<float>(serializable.Range, 1f, 1000f);
			伤害倍率 = new NumericValue<float>(serializable.DamageMultiplier, 0.01f, 1000f);
			防御倍率 = new NumericValue<float>(serializable.DefenseMultiplier, 0.01f, 1000f);
			速度倍率 = new NumericValue<float>(serializable.SpeedMultiplier, 0.01f, 1000f);
			高级行为模式 = serializable.ImprovedAi;
			容量 = new NumericValue<int>(serializable.Capacity, 1, 1000);
			控制类型 = serializable.ActivationType;
			发射音效 = serializable.LaunchSound;
			引用发射效果 = serializable.LaunchEffectPrefab;
			按钮贴图 = serializable.ControlButtonIcon;

			OnDataDeserialized(serializable, database);
		}

		public void Save(DroneBaySerializable serializable)
		{
			serializable.EnergyConsumption = 释放能耗.Value;
			serializable.PassiveEnergyConsumption = 被动能耗.Value;
			serializable.Range = 索敌范围.Value;
			serializable.DamageMultiplier = 伤害倍率.Value;
			serializable.DefenseMultiplier = 防御倍率.Value;
			serializable.SpeedMultiplier = 速度倍率.Value;
			serializable.ImprovedAi = 高级行为模式;
			serializable.Capacity = 容量.Value;
			serializable.ActivationType = 控制类型;
			serializable.LaunchSound = 发射音效;
			serializable.LaunchEffectPrefab = 引用发射效果;
			serializable.ControlButtonIcon = 按钮贴图;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<DroneBay> Id;

		public NumericValue<float> 释放能耗 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 被动能耗 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 索敌范围 = new NumericValue<float>(0, 1f, 1000f);
		public NumericValue<float> 伤害倍率 = new NumericValue<float>(0, 0.01f, 1000f);
		public NumericValue<float> 防御倍率 = new NumericValue<float>(0, 0.01f, 1000f);
		public NumericValue<float> 速度倍率 = new NumericValue<float>(0, 0.01f, 1000f);
		public bool 高级行为模式;
		public NumericValue<int> 容量 = new NumericValue<int>(0, 1, 1000);
		public ActivationType 控制类型;
		public string 发射音效;
		public string 引用发射效果;
		public string 按钮贴图;

		public static DroneBay DefaultValue { get; private set; }
	}
}
