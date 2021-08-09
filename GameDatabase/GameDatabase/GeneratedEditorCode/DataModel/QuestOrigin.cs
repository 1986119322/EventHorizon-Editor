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
	public partial class 任务起始地点
	{
		partial void OnDataDeserialized(QuestOriginSerializable serializable, Database database);
		partial void OnDataSerialized(ref QuestOriginSerializable serializable);

		public 任务起始地点() {}

		public 任务起始地点(QuestOriginSerializable serializable, Database database)
		{
			类型 = serializable.Type;
			筛选势力 = new RequiredFactions(serializable.Factions, database);
			最小距离 = new NumericValue<int>(serializable.MinDistance, 0, 9999);
			最大距离 = new NumericValue<int>(serializable.MaxDistance, 0, 9999);
			最小声望 = new NumericValue<int>(serializable.MinRelations, -100, 100);
			最大声望 = new NumericValue<int>(serializable.MaxRelations, -100, 100);

			OnDataDeserialized(serializable, database);
		}

		public QuestOriginSerializable Serialize()
		{
			var serializable = new QuestOriginSerializable();
			serializable.Type = 类型;
			serializable.Factions = 筛选势力.Serialize();
			serializable.MinDistance = 最小距离.Value;
			serializable.MaxDistance = 最大距离.Value;
			serializable.MinRelations = 最小声望.Value;
			serializable.MaxRelations = 最大声望.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public QuestOriginType 类型;
		public RequiredFactions 筛选势力 = new RequiredFactions();
		public NumericValue<int> 最小距离 = new NumericValue<int>(0, 0, 9999);
		public NumericValue<int> 最大距离 = new NumericValue<int>(0, 0, 9999);
		public NumericValue<int> 最小声望 = new NumericValue<int>(0, -100, 100);
		public NumericValue<int> 最大声望 = new NumericValue<int>(0, -100, 100);

		public static 任务起始地点 DefaultValue { get; private set; }
	}
}
