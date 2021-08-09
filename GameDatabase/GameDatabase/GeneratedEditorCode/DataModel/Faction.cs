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
	public partial class Faction
	{
		partial void OnDataDeserialized(FactionSerializable serializable, Database database);
		partial void OnDataSerialized(ref FactionSerializable serializable);


		public Faction(FactionSerializable serializable, Database database)
		{
			Id = new ItemId<Faction>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			颜色 = Helpers.ColorFromString(serializable.Color);
			要塞出现距离 = new NumericValue<int>(serializable.HomeStarDistance, 0, 1000);
			敌对飞船出现距离 = new NumericValue<int>(serializable.WanderingShipsDistance, 0, 1000);
			隐藏 = serializable.Hidden;
			敌对 = serializable.Hostile;

			OnDataDeserialized(serializable, database);
		}

		public void Save(FactionSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.HomeStarDistance = 要塞出现距离.Value;
			serializable.WanderingShipsDistance = 敌对飞船出现距离.Value;
			serializable.Hidden = 隐藏;
			serializable.Hostile = 敌对;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Faction> Id;

		public string 名称;
		public System.Drawing.Color 颜色;
		public NumericValue<int> 要塞出现距离 = new NumericValue<int>(0, 0, 1000);
		public NumericValue<int> 敌对飞船出现距离 = new NumericValue<int>(0, 0, 1000);
		public bool 隐藏;
		public bool 敌对;

		public static Faction DefaultValue { get; private set; }
	}
}
