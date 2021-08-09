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
	public partial class GalaxySettings
	{
		partial void OnDataDeserialized(GalaxySettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref GalaxySettingsSerializable serializable);


		public GalaxySettings(GalaxySettingsSerializable serializable, Database database)
		{
			废弃太空站所属势力 = database.GetFactionId(serializable.AbandonedStarbaseFaction);
			开局飞船配置 = serializable.StartingShipBuilds?.Select(id => new Wrapper<ShipBuild> { Item = database.GetShipBuildId(id) }).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(GalaxySettingsSerializable serializable)
		{
			serializable.AbandonedStarbaseFaction = 废弃太空站所属势力.Value;
			if (开局飞船配置 == null || 开局飞船配置.Length == 0)
			    serializable.StartingShipBuilds = null;
			else
			    serializable.StartingShipBuilds = 开局飞船配置.Select(wrapper => wrapper.Item.Value).ToArray();
			OnDataSerialized(ref serializable);
		}

		public ItemId<Faction> 废弃太空站所属势力 = ItemId<Faction>.Empty;
		public Wrapper<ShipBuild>[] 开局飞船配置;

		public static GalaxySettings DefaultValue { get; private set; }
	}
}
