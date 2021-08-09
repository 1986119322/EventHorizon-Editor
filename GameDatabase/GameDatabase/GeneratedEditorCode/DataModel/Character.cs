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
	public partial class Character
	{
		partial void OnDataDeserialized(CharacterSerializable serializable, Database database);
		partial void OnDataSerialized(ref CharacterSerializable serializable);


		public Character(CharacterSerializable serializable, Database database)
		{
			Id = new ItemId<Character>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			头像 = serializable.AvatarIcon;
			势力 = database.GetFactionId(serializable.Faction);
			物品栏 = database.GetLootId(serializable.Inventory);
			舰队 = database.GetFleetId(serializable.Fleet);
			初始好感度 = new NumericValue<int>(serializable.Relations, -100, 100);
			是否唯一 = serializable.IsUnique;

			OnDataDeserialized(serializable, database);
		}

		public void Save(CharacterSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.AvatarIcon = 头像;
			serializable.Faction = 势力.Value;
			serializable.Inventory = 物品栏.Value;
			serializable.Fleet = 舰队.Value;
			serializable.Relations = 初始好感度.Value;
			serializable.IsUnique = 是否唯一;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Character> Id;

		public string 名称;
		public string 头像;
		public ItemId<Faction> 势力 = ItemId<Faction>.Empty;
		public ItemId<LootModel> 物品栏 = ItemId<LootModel>.Empty;
		public ItemId<Fleet> 舰队 = ItemId<Fleet>.Empty;
		public NumericValue<int> 初始好感度 = new NumericValue<int>(0, -100, 100);
		public bool 是否唯一;

		public static Character DefaultValue { get; private set; }
	}
}
