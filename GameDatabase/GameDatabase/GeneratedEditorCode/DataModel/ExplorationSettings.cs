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
	public partial class ExplorationSettings
	{
		partial void OnDataDeserialized(ExplorationSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref ExplorationSettingsSerializable serializable);


		public ExplorationSettings(ExplorationSettingsSerializable serializable, Database database)
		{
			地面哨站船体 = database.GetShipId(serializable.OutpostShip);
			地面炮塔船体 = database.GetShipId(serializable.TurretShip);
			感染星球势力 = database.GetFactionId(serializable.InfectedPlanetFaction);
			巢穴飞船配置 = database.GetShipBuildId(serializable.HiveShipBuild);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ExplorationSettingsSerializable serializable)
		{
			serializable.OutpostShip = 地面哨站船体.Value;
			serializable.TurretShip = 地面炮塔船体.Value;
			serializable.InfectedPlanetFaction = 感染星球势力.Value;
			serializable.HiveShipBuild = 巢穴飞船配置.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Ship> 地面哨站船体 = ItemId<Ship>.Empty;
		public ItemId<Ship> 地面炮塔船体 = ItemId<Ship>.Empty;
		public ItemId<Faction> 感染星球势力 = ItemId<Faction>.Empty;
		public ItemId<ShipBuild> 巢穴飞船配置 = ItemId<ShipBuild>.Empty;

		public static ExplorationSettings DefaultValue { get; private set; }
	}
}
