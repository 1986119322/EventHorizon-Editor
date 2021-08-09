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
	public partial class QuestItem
	{
		partial void OnDataDeserialized(QuestItemSerializable serializable, Database database);
		partial void OnDataSerialized(ref QuestItemSerializable serializable);


		public QuestItem(QuestItemSerializable serializable, Database database)
		{
			Id = new ItemId<QuestItem>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			描述 = serializable.Description;
			图标 = serializable.Icon;
			颜色 = Helpers.ColorFromString(serializable.Color);
			价格 = new NumericValue<int>(serializable.Price, 0, 999999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(QuestItemSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.Description = 描述;
			serializable.Icon = 图标;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.Price = 价格.Value;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<QuestItem> Id;

		public string 名称;
		public string 描述;
		public string 图标;
		public System.Drawing.Color 颜色;
		public NumericValue<int> 价格 = new NumericValue<int>(0, 0, 999999999);

		public static QuestItem DefaultValue { get; private set; }
	}
}
