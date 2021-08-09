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
	public partial class Fleet
	{
		partial void OnDataDeserialized(FleetSerializable serializable, Database database);
		partial void OnDataSerialized(ref FleetSerializable serializable);


		public Fleet(FleetSerializable serializable, Database database)
		{
			Id = new ItemId<Fleet>(serializable.Id, serializable.FileName);
			筛选势力 = new RequiredFactions(serializable.Factions, database);
			等级加成 = new NumericValue<int>(serializable.LevelBonus, -10000, 10000);
			无随机船 = serializable.NoRandomShips;
			战斗时间限制 = new NumericValue<int>(serializable.CombatTimeLimit, 0, 999);
			战利品掉落条件 = serializable.LootCondition;
			经验值掉落条件 = serializable.ExpCondition;
			指定飞船配置 = serializable.SpecificShips?.Select(id => new Wrapper<ShipBuild> { Item = database.GetShipBuildId(id) }).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(FleetSerializable serializable)
		{
			serializable.Factions = 筛选势力.Serialize();
			serializable.LevelBonus = 等级加成.Value;
			serializable.NoRandomShips = 无随机船;
			serializable.CombatTimeLimit = 战斗时间限制.Value;
			serializable.LootCondition = 战利品掉落条件;
			serializable.ExpCondition = 经验值掉落条件;
			if (指定飞船配置 == null || 指定飞船配置.Length == 0)
			    serializable.SpecificShips = null;
			else
			    serializable.SpecificShips = 指定飞船配置.Select(wrapper => wrapper.Item.Value).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Fleet> Id;

		public RequiredFactions 筛选势力 = new RequiredFactions();
		public NumericValue<int> 等级加成 = new NumericValue<int>(0, -10000, 10000);
		public bool 无随机船;
		public NumericValue<int> 战斗时间限制 = new NumericValue<int>(0, 0, 999);
		public RewardCondition 战利品掉落条件;
		public RewardCondition 经验值掉落条件;
		public Wrapper<ShipBuild>[] 指定飞船配置;

		public static Fleet DefaultValue { get; private set; }
	}
}
