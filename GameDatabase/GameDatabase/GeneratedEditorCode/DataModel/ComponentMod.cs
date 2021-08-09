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
	public partial class ComponentMod
	{
		partial void OnDataDeserialized(ComponentModSerializable serializable, Database database);
		partial void OnDataSerialized(ref ComponentModSerializable serializable);


		public ComponentMod(ComponentModSerializable serializable, Database database)
		{
			Id = new ItemId<ComponentMod>(serializable.Id, serializable.FileName);
			类型 = serializable.Type;

			OnDataDeserialized(serializable, database);
		}

		public void Save(ComponentModSerializable serializable)
		{
			serializable.Type = 类型;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<ComponentMod> Id;

		public ComponentModType 类型;

		public static ComponentMod DefaultValue { get; private set; }
	}
}
