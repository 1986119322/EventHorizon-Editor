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
	public partial class ShipBuild
	{
		partial void OnDataDeserialized(ShipBuildSerializable serializable, Database database);
		partial void OnDataSerialized(ref ShipBuildSerializable serializable);


		public ShipBuild(ShipBuildSerializable serializable, Database database)
		{
			Id = new ItemId<ShipBuild>(serializable.Id, serializable.FileName);
			飞船 = database.GetShipId(serializable.ShipId);
			if (飞船.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".飞船 不能为空");
			游戏中不启用 = serializable.NotAvailableInGame;
			难度等级 = serializable.DifficultyClass;
			会建造的势力 = database.GetFactionId(serializable.BuildFaction);
			组件列表 = serializable.Components?.Select(item => new InstalledComponent(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ShipBuildSerializable serializable)
		{
			serializable.ShipId = 飞船.Value;
			serializable.NotAvailableInGame = 游戏中不启用;
			serializable.DifficultyClass = 难度等级;
			serializable.BuildFaction = 会建造的势力.Value;
			if (组件列表 == null || 组件列表.Length == 0)
			    serializable.Components = null;
			else
			    serializable.Components = 组件列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<ShipBuild> Id;

		public ItemId<Ship> 飞船 = ItemId<Ship>.Empty;
		public bool 游戏中不启用;
		public DifficultyClass 难度等级;
		public ItemId<Faction> 会建造的势力 = ItemId<Faction>.Empty;
		public InstalledComponent[] 组件列表;

		public static ShipBuild DefaultValue { get; private set; }
	}
}
