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
	public partial class DatabaseSettings
	{
		partial void OnDataDeserialized(DatabaseSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref DatabaseSettingsSerializable serializable);


		public DatabaseSettings(DatabaseSettingsSerializable serializable, Database database)
		{
			数据库版本 = new NumericValue<int>(serializable.DatabaseVersion, 1, 2147483647);
			模组名 = serializable.ModName;
			模组唯一标识 = serializable.ModId;
			模组版本 = new NumericValue<int>(serializable.ModVersion, -2147483648, 2147483647);
			不装载原版数据库 = serializable.UnloadOriginalDatabase;

			OnDataDeserialized(serializable, database);
		}

		public void Save(DatabaseSettingsSerializable serializable)
		{
			serializable.DatabaseVersion = 数据库版本.Value;
			serializable.ModName = 模组名;
			serializable.ModId = 模组唯一标识;
			serializable.ModVersion = 模组版本.Value;
			serializable.UnloadOriginalDatabase = 不装载原版数据库;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 数据库版本 = new NumericValue<int>(0, 1, 2147483647);
		public string 模组名;
		public string 模组唯一标识;
		public NumericValue<int> 模组版本 = new NumericValue<int>(0, -2147483648, 2147483647);
		public bool 不装载原版数据库;

		public static DatabaseSettings DefaultValue { get; private set; }
	}
}
