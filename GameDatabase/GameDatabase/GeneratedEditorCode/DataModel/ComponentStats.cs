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
	public partial class ComponentStats
	{
		partial void OnDataDeserialized(ComponentStatsSerializable serializable, Database database);
		partial void OnDataSerialized(ref ComponentStatsSerializable serializable);


		public ComponentStats(ComponentStatsSerializable serializable, Database database)
		{
			Id = new ItemId<ComponentStats>(serializable.Id, serializable.FileName);
			属性计算方式 = serializable.Type;
			装甲值 = new NumericValue<float>(serializable.ArmorPoints, -1000000f, 1000000f);
			装甲修复速率 = new NumericValue<float>(serializable.ArmorRepairRate, -1000000f, 1000000f);
			装甲修复间隔倍率 = new NumericValue<float>(serializable.ArmorRepairCooldownModifier, -1f, 1f);
			能量值 = new NumericValue<float>(serializable.EnergyPoints, -1000000f, 1000000f);
			能量回充 = new NumericValue<float>(serializable.EnergyRechargeRate, -1000000f, 1000000f);
			能量回充间隔倍率 = new NumericValue<float>(serializable.EnergyRechargeCooldownModifier, -5f, 5f);
			护盾值 = new NumericValue<float>(serializable.ShieldPoints, -1000000f, 1000000f);
			护盾充能速率 = new NumericValue<float>(serializable.ShieldRechargeRate, -1000000f, 1000000f);
			护盾充能间隔倍率 = new NumericValue<float>(serializable.ShieldRechargeCooldownModifier, -5f, 5f);
			重量 = new NumericValue<float>(serializable.Weight, -1000000f, 1000000f);
			撞击伤害 = new NumericValue<float>(serializable.RammingDamage, -1000000f, 1000000f);
			能量吸收 = new NumericValue<float>(serializable.EnergyAbsorption, -1000000f, 1000000f);
			动能抗性 = new NumericValue<float>(serializable.KineticResistance, -1000000f, 1000000f);
			能量抗性 = new NumericValue<float>(serializable.EnergyResistance, -1000000f, 1000000f);
			热能抗性 = new NumericValue<float>(serializable.ThermalResistance, -1000000f, 1000000f);
			引擎推力 = new NumericValue<float>(serializable.EnginePower, 0f, 2000f);
			引擎扭矩 = new NumericValue<float>(serializable.TurnRate, 0f, 2000f);
			自动驾驶 = serializable.Autopilot;
			无人机索敌范围增幅 = new NumericValue<float>(serializable.DroneRangeModifier, -50f, 50f);
			无人机伤害增幅 = new NumericValue<float>(serializable.DroneDamageModifier, -50f, 50f);
			无人机防御增幅 = new NumericValue<float>(serializable.DroneDefenseModifier, -50f, 50f);
			无人机速度增幅 = new NumericValue<float>(serializable.DroneSpeedModifier, -50f, 50f);
			无人机每秒建造数 = new NumericValue<float>(serializable.DronesBuiltPerSecond, 0f, 100f);
			无人机建造时间增幅 = new NumericValue<float>(serializable.DroneBuildTimeModifier, 0f, 100f);
			武器射速增幅 = new NumericValue<float>(serializable.WeaponFireRateModifier, -100f, 100f);
			武器伤害增幅 = new NumericValue<float>(serializable.WeaponDamageModifier, -100f, 100f);
			武器射程增幅 = new NumericValue<float>(serializable.WeaponRangeModifier, -100f, 100f);
			武器能耗增幅 = new NumericValue<float>(serializable.WeaponEnergyCostModifier, -100f, 100f);
			更改炮管类型 = serializable.AlterWeaponPlatform;

			OnDataDeserialized(serializable, database);
		}

		public void Save(ComponentStatsSerializable serializable)
		{
			serializable.Type = 属性计算方式;
			serializable.ArmorPoints = 装甲值.Value;
			serializable.ArmorRepairRate = 装甲修复速率.Value;
			serializable.ArmorRepairCooldownModifier = 装甲修复间隔倍率.Value;
			serializable.EnergyPoints = 能量值.Value;
			serializable.EnergyRechargeRate = 能量回充.Value;
			serializable.EnergyRechargeCooldownModifier = 能量回充间隔倍率.Value;
			serializable.ShieldPoints = 护盾值.Value;
			serializable.ShieldRechargeRate = 护盾充能速率.Value;
			serializable.ShieldRechargeCooldownModifier = 护盾充能间隔倍率.Value;
			serializable.Weight = 重量.Value;
			serializable.RammingDamage = 撞击伤害.Value;
			serializable.EnergyAbsorption = 能量吸收.Value;
			serializable.KineticResistance = 动能抗性.Value;
			serializable.EnergyResistance = 能量抗性.Value;
			serializable.ThermalResistance = 热能抗性.Value;
			serializable.EnginePower = 引擎推力.Value;
			serializable.TurnRate = 引擎扭矩.Value;
			serializable.Autopilot = 自动驾驶;
			serializable.DroneRangeModifier = 无人机索敌范围增幅.Value;
			serializable.DroneDamageModifier = 无人机伤害增幅.Value;
			serializable.DroneDefenseModifier = 无人机防御增幅.Value;
			serializable.DroneSpeedModifier = 无人机速度增幅.Value;
			serializable.DronesBuiltPerSecond = 无人机每秒建造数.Value;
			serializable.DroneBuildTimeModifier = 无人机建造时间增幅.Value;
			serializable.WeaponFireRateModifier = 武器射速增幅.Value;
			serializable.WeaponDamageModifier = 武器伤害增幅.Value;
			serializable.WeaponRangeModifier = 武器射程增幅.Value;
			serializable.WeaponEnergyCostModifier = 武器能耗增幅.Value;
			serializable.AlterWeaponPlatform = 更改炮管类型;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<ComponentStats> Id;

		public ComponentStatsType 属性计算方式;
		public NumericValue<float> 装甲值 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 装甲修复速率 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 装甲修复间隔倍率 = new NumericValue<float>(0, -1f, 1f);
		public NumericValue<float> 能量值 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 能量回充 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 能量回充间隔倍率 = new NumericValue<float>(0, -5f, 5f);
		public NumericValue<float> 护盾值 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 护盾充能速率 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 护盾充能间隔倍率 = new NumericValue<float>(0, -5f, 5f);
		public NumericValue<float> 重量 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 撞击伤害 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 能量吸收 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 动能抗性 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 能量抗性 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 热能抗性 = new NumericValue<float>(0, -1000000f, 1000000f);
		public NumericValue<float> 引擎推力 = new NumericValue<float>(0, 0f, 2000f);
		public NumericValue<float> 引擎扭矩 = new NumericValue<float>(0, 0f, 2000f);
		public bool 自动驾驶;
		public NumericValue<float> 无人机索敌范围增幅 = new NumericValue<float>(0, -50f, 50f);
		public NumericValue<float> 无人机伤害增幅 = new NumericValue<float>(0, -50f, 50f);
		public NumericValue<float> 无人机防御增幅 = new NumericValue<float>(0, -50f, 50f);
		public NumericValue<float> 无人机速度增幅 = new NumericValue<float>(0, -50f, 50f);
		public NumericValue<float> 无人机每秒建造数 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 无人机建造时间增幅 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 武器射速增幅 = new NumericValue<float>(0, -100f, 100f);
		public NumericValue<float> 武器伤害增幅 = new NumericValue<float>(0, -100f, 100f);
		public NumericValue<float> 武器射程增幅 = new NumericValue<float>(0, -100f, 100f);
		public NumericValue<float> 武器能耗增幅 = new NumericValue<float>(0, -100f, 100f);
		public PlatformType 更改炮管类型;

		public static ComponentStats DefaultValue { get; private set; }
	}
}
