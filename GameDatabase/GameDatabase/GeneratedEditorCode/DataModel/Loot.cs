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
	public partial class LootModel
	{
		partial void OnDataDeserialized(LootSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootSerializable serializable);


		public LootModel(LootSerializable serializable, Database database)
		{
			Id = new ItemId<LootModel>(serializable.Id, serializable.FileName);
			物品列表 = new 物品列表(serializable.Loot, database);

			OnDataDeserialized(serializable, database);
		}

		public void Save(LootSerializable serializable)
		{
			serializable.Loot = 物品列表.Serialize();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<LootModel> Id;

		public 物品列表 物品列表 = new 物品列表();

		public static LootModel DefaultValue { get; private set; }
	}
}
