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
	public partial class AmmunitionObsolete
	{
		partial void OnDataDeserialized(AmmunitionObsoleteSerializable serializable, Database database);
		partial void OnDataSerialized(ref AmmunitionObsoleteSerializable serializable);


		public AmmunitionObsolete(AmmunitionObsoleteSerializable serializable, Database database)
		{
			Id = new ItemId<AmmunitionObsolete>(serializable.Id, serializable.FileName);
			类型 = serializable.AmmunitionClass;
			伤害类型 = serializable.DamageType;
			冲击力 = new NumericValue<float>(serializable.Impulse, 0f, 10f);
			后坐力 = new NumericValue<float>(serializable.Recoil, 0f, 10f);
			大小 = new NumericValue<float>(serializable.Size, 0f, 1000f);
			发射偏移距离 = serializable.InitialPosition;
			影响范围 = new NumericValue<float>(serializable.AreaOfEffect, 0f, 1000f);
			伤害 = new NumericValue<float>(serializable.Damage, 0f, 1E+09f);
			射程 = new NumericValue<float>(serializable.Range, 0f, 1000f);
			初速 = new NumericValue<float>(serializable.Velocity, 0f, 1000f);
			存在时间 = new NumericValue<float>(serializable.LifeTime, 0f, 1E+09f);
			生命值 = new NumericValue<int>(serializable.HitPoints, 0, 999999999);
			忽略发射速度 = serializable.IgnoresShipVelocity;
			能耗 = new NumericValue<float>(serializable.EnergyCost, 0f, 1E+09f);
			配对弹头 = database.GetAmmunitionObsoleteId(serializable.CoupledAmmunitionId);
			颜色 = Helpers.ColorFromString(serializable.Color);
			发射音效 = serializable.FireSound;
			击中音效 = serializable.HitSound;
			击中效果 = serializable.HitEffectPrefab;
			引用子弹 = serializable.BulletPrefab;

			OnDataDeserialized(serializable, database);
		}

		public void Save(AmmunitionObsoleteSerializable serializable)
		{
			serializable.AmmunitionClass = 类型;
			serializable.DamageType = 伤害类型;
			serializable.Impulse = 冲击力.Value;
			serializable.Recoil = 后坐力.Value;
			serializable.Size = 大小.Value;
			serializable.InitialPosition = 发射偏移距离;
			serializable.AreaOfEffect = 影响范围.Value;
			serializable.Damage = 伤害.Value;
			serializable.Range = 射程.Value;
			serializable.Velocity = 初速.Value;
			serializable.LifeTime = 存在时间.Value;
			serializable.HitPoints = 生命值.Value;
			serializable.IgnoresShipVelocity = 忽略发射速度;
			serializable.EnergyCost = 能耗.Value;
			serializable.CoupledAmmunitionId = 配对弹头.Value;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.FireSound = 发射音效;
			serializable.HitSound = 击中音效;
			serializable.HitEffectPrefab = 击中效果;
			serializable.BulletPrefab = 引用子弹;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<AmmunitionObsolete> Id;

		public AmmunitionClassObsolete 类型;
		public DamageType 伤害类型;
		public NumericValue<float> 冲击力 = new NumericValue<float>(0, 0f, 10f);
		public NumericValue<float> 后坐力 = new NumericValue<float>(0, 0f, 10f);
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0f, 1000f);
		public Vector2 发射偏移距离;
		public NumericValue<float> 影响范围 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 伤害 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 射程 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 初速 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 存在时间 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<int> 生命值 = new NumericValue<int>(0, 0, 999999999);
		public bool 忽略发射速度;
		public NumericValue<float> 能耗 = new NumericValue<float>(0, 0f, 1E+09f);
		public ItemId<AmmunitionObsolete> 配对弹头 = ItemId<AmmunitionObsolete>.Empty;
		public System.Drawing.Color 颜色;
		public string 发射音效;
		public string 击中音效;
		public string 击中效果;
		public string 引用子弹;

		public static AmmunitionObsolete DefaultValue { get; private set; }
	}
}
