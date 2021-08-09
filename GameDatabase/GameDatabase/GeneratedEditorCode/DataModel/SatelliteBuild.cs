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
	public partial class SatelliteBuild
	{
		partial void OnDataDeserialized(SatelliteBuildSerializable serializable, Database database);
		partial void OnDataSerialized(ref SatelliteBuildSerializable serializable);


		public SatelliteBuild(SatelliteBuildSerializable serializable, Database database)
		{
			Id = new ItemId<SatelliteBuild>(serializable.Id, serializable.FileName);
			僚机 = database.GetSatelliteId(serializable.SatelliteId);
			if (僚机.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".僚机 不能为空");
			游戏中不启用 = serializable.NotAvailableInGame;
			难度等级 = serializable.DifficultyClass;
			组件列表 = serializable.Components?.Select(item => new InstalledComponent(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(SatelliteBuildSerializable serializable)
		{
			serializable.SatelliteId = 僚机.Value;
			serializable.NotAvailableInGame = 游戏中不启用;
			serializable.DifficultyClass = 难度等级;
			if (组件列表 == null || 组件列表.Length == 0)
			    serializable.Components = null;
			else
			    serializable.Components = 组件列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<SatelliteBuild> Id;

		public ItemId<Satellite> 僚机 = ItemId<Satellite>.Empty;
		public bool 游戏中不启用;
		public DifficultyClass 难度等级;
		public InstalledComponent[] 组件列表;

		public static SatelliteBuild DefaultValue { get; private set; }
	}
}
