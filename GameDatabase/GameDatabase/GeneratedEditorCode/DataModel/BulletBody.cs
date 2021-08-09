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
	public partial class BulletBody
	{
		partial void OnDataDeserialized(BulletBodySerializable serializable, Database database);
		partial void OnDataSerialized(ref BulletBodySerializable serializable);

		public BulletBody() {}

		public BulletBody(BulletBodySerializable serializable, Database database)
		{
			类型 = serializable.Type;
			大小 = new NumericValue<float>(serializable.Size, 0f, 1000f);
			初速 = new NumericValue<float>(serializable.Velocity, 0f, 1000f);
			射程 = new NumericValue<float>(serializable.Range, 0f, 1E+09f);
			持续时间 = new NumericValue<float>(serializable.Lifetime, 0f, 1E+09f);
			重量 = new NumericValue<float>(serializable.Weight, 0f, 1E+09f);
			生命值 = new NumericValue<int>(serializable.HitPoints, 0, 999999999);
			颜色 = Helpers.ColorFromString(serializable.Color);
			子弹模板 = database.GetBulletPrefabId(serializable.BulletPrefab);
			能耗 = new NumericValue<float>(serializable.EnergyCost, 0f, 1E+09f);
			可被点防攻击 = serializable.CanBeDisarmed;
			可击中友好目标 = serializable.FriendlyFire;

			OnDataDeserialized(serializable, database);
		}

		public BulletBodySerializable Serialize()
		{
			var serializable = new BulletBodySerializable();
			serializable.Type = 类型;
			serializable.Size = 大小.Value;
			serializable.Velocity = 初速.Value;
			serializable.Range = 射程.Value;
			serializable.Lifetime = 持续时间.Value;
			serializable.Weight = 重量.Value;
			serializable.HitPoints = 生命值.Value;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.BulletPrefab = 子弹模板.Value;
			serializable.EnergyCost = 能耗.Value;
			serializable.CanBeDisarmed = 可被点防攻击;
			serializable.FriendlyFire = 可击中友好目标;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public BulletType 类型;
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 初速 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 射程 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 持续时间 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 重量 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<int> 生命值 = new NumericValue<int>(0, 0, 999999999);
		public System.Drawing.Color 颜色;
		public ItemId<BulletPrefab> 子弹模板 = ItemId<BulletPrefab>.Empty;
		public NumericValue<float> 能耗 = new NumericValue<float>(0, 0f, 1E+09f);
		public bool 可被点防攻击;
		public bool 可击中友好目标;

		public static BulletBody DefaultValue { get; private set; }
	}
}
