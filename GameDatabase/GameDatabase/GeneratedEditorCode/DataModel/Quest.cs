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
	public partial class QuestModel
	{
		partial void OnDataDeserialized(QuestSerializable serializable, Database database);
		partial void OnDataSerialized(ref QuestSerializable serializable);


		public QuestModel(QuestSerializable serializable, Database database)
		{
			Id = new ItemId<QuestModel>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			类型 = serializable.QuestType;
			触发方式 = serializable.StartCondition;
			比重 = new NumericValue<float>(serializable.Weight, 0f, 1000f);
			起始地点 = new 任务起始地点(serializable.Origin, database);
			触发条件 = new 条件(serializable.Requirement, database);
			等级 = new NumericValue<int>(serializable.Level, 0, 1000);
			节点 = serializable.Nodes?.Select(item => new 节点(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(QuestSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.QuestType = 类型;
			serializable.StartCondition = 触发方式;
			serializable.Weight = 比重.Value;
			serializable.Origin = 起始地点.Serialize();
			serializable.Requirement = 触发条件.Serialize();
			serializable.Level = 等级.Value;
			if (节点 == null || 节点.Length == 0)
			    serializable.Nodes = null;
			else
			    serializable.Nodes = 节点.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<QuestModel> Id;

		public string 名称;
		public QuestType 类型;
		public StartCondition 触发方式;
		public NumericValue<float> 比重 = new NumericValue<float>(0, 0f, 1000f);
		public 任务起始地点 起始地点 = new 任务起始地点();
		public 条件 触发条件 = new 条件();
		public NumericValue<int> 等级 = new NumericValue<int>(0, 0, 1000);
		public 节点[] 节点;

		public static QuestModel DefaultValue { get; private set; }
	}
}
