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
	public partial class LootItem
	{
		partial void OnDataDeserialized(LootItemSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootItemSerializable serializable);

		public LootItem() {}

		public LootItem(LootItemSerializable serializable, Database database)
		{
			比重 = new NumericValue<float>(serializable.Weight, -3.402823E+38f, 3.402823E+38f);
			物品列表 = new 物品列表(serializable.Loot, database);

			OnDataDeserialized(serializable, database);
		}

		public LootItemSerializable Serialize()
		{
			var serializable = new LootItemSerializable();
			serializable.Weight = 比重.Value;
			serializable.Loot = 物品列表.Serialize();
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public NumericValue<float> 比重 = new NumericValue<float>(0, -3.402823E+38f, 3.402823E+38f);
		public 物品列表 物品列表 = new 物品列表();

		public static LootItem DefaultValue { get; private set; }
	}
}
