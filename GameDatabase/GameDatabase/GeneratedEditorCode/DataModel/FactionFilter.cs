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
	public partial class RequiredFactions
	{
		partial void OnDataDeserialized(FactionFilterSerializable serializable, Database database);
		partial void OnDataSerialized(ref FactionFilterSerializable serializable);

		public RequiredFactions() {}

		public RequiredFactions(FactionFilterSerializable serializable, Database database)
		{
			类型 = serializable.Type;
			势力列表 = serializable.List?.Select(id => new Wrapper<Faction> { Item = database.GetFactionId(id) }).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public FactionFilterSerializable Serialize()
		{
			var serializable = new FactionFilterSerializable();
			serializable.Type = 类型;
			if (势力列表 == null || 势力列表.Length == 0)
			    serializable.List = null;
			else
			    serializable.List = 势力列表.Select(wrapper => wrapper.Item.Value).ToArray();
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public FactionFilterType 类型;
		public Wrapper<Faction>[] 势力列表;

		public static RequiredFactions DefaultValue { get; private set; }
	}
}
