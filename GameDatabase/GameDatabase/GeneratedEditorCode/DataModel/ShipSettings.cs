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
	public partial class ShipSettings
	{
		partial void OnDataDeserialized(ShipSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref ShipSettingsSerializable serializable);


		public ShipSettings(ShipSettingsSerializable serializable, Database database)
		{
			每格基础重量 = new NumericValue<float>(serializable.DefaultWeightPerCell, 1f, 1000000f);
			每格最小重量 = new NumericValue<float>(serializable.MinimumWeightPerCell, 1f, 1000000f);
			基础装甲值 = new NumericValue<float>(serializable.BaseArmorPoints, 0f, 1000000f);
			每格装甲值 = new NumericValue<float>(serializable.ArmorPointsPerCell, 0f, 1000000f);
			装甲值回复间隔 = new NumericValue<float>(serializable.ArmorRepairCooldown, 0f, 60f);
			基础能量值 = new NumericValue<float>(serializable.BaseEnergyPoints, 0f, 1000000f);
			基础能量回充 = new NumericValue<float>(serializable.BaseEnergyRechargeRate, 0f, 1000000f);
			能量回充间隔 = new NumericValue<float>(serializable.EnergyRechargeCooldown, 0f, 60f);
			基础护盾回充 = new NumericValue<float>(serializable.BaseShieldRechargeRate, 0f, 1000000f);
			护盾回充间隔 = new NumericValue<float>(serializable.ShieldRechargeCooldown, 0f, 60f);
			基础无人机重建速度 = new NumericValue<float>(serializable.BaseDroneReconstructionSpeed, 0f, 100f);
			最大速度 = new NumericValue<float>(serializable.MaxVelocity, 5f, 30f);
			最大转速 = new NumericValue<float>(serializable.MaxTurnRate, 5f, 30f);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ShipSettingsSerializable serializable)
		{
			serializable.DefaultWeightPerCell = 每格基础重量.Value;
			serializable.MinimumWeightPerCell = 每格最小重量.Value;
			serializable.BaseArmorPoints = 基础装甲值.Value;
			serializable.ArmorPointsPerCell = 每格装甲值.Value;
			serializable.ArmorRepairCooldown = 装甲值回复间隔.Value;
			serializable.BaseEnergyPoints = 基础能量值.Value;
			serializable.BaseEnergyRechargeRate = 基础能量回充.Value;
			serializable.EnergyRechargeCooldown = 能量回充间隔.Value;
			serializable.BaseShieldRechargeRate = 基础护盾回充.Value;
			serializable.ShieldRechargeCooldown = 护盾回充间隔.Value;
			serializable.BaseDroneReconstructionSpeed = 基础无人机重建速度.Value;
			serializable.MaxVelocity = 最大速度.Value;
			serializable.MaxTurnRate = 最大转速.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<float> 每格基础重量 = new NumericValue<float>(0, 1f, 1000000f);
		public NumericValue<float> 每格最小重量 = new NumericValue<float>(0, 1f, 1000000f);
		public NumericValue<float> 基础装甲值 = new NumericValue<float>(0, 0f, 1000000f);
		public NumericValue<float> 每格装甲值 = new NumericValue<float>(0, 0f, 1000000f);
		public NumericValue<float> 装甲值回复间隔 = new NumericValue<float>(0, 0f, 60f);
		public NumericValue<float> 基础能量值 = new NumericValue<float>(0, 0f, 1000000f);
		public NumericValue<float> 基础能量回充 = new NumericValue<float>(0, 0f, 1000000f);
		public NumericValue<float> 能量回充间隔 = new NumericValue<float>(0, 0f, 60f);
		public NumericValue<float> 基础护盾回充 = new NumericValue<float>(0, 0f, 1000000f);
		public NumericValue<float> 护盾回充间隔 = new NumericValue<float>(0, 0f, 60f);
		public NumericValue<float> 基础无人机重建速度 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 最大速度 = new NumericValue<float>(0, 5f, 30f);
		public NumericValue<float> 最大转速 = new NumericValue<float>(0, 5f, 30f);

		public static ShipSettings DefaultValue { get; private set; }
	}
}
