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
	public partial class ComponentRestrictions
	{
		partial void OnDataDeserialized(ComponentRestrictionsSerializable serializable, Database database);
		partial void OnDataSerialized(ref ComponentRestrictionsSerializable serializable);

		public ComponentRestrictions() {}

		public ComponentRestrictions(ComponentRestrictionsSerializable serializable, Database database)
		{
			可用舰船等级 = serializable.ShipSizes?.Select(item => new ValueWrapper<SizeClass> { Value = item }).ToArray();
			生物船不可用 = serializable.NotForOrganicShips;
			机械船不可用 = serializable.NotForMechanicShips;
			唯一组件标签 = serializable.UniqueComponentTag;

			OnDataDeserialized(serializable, database);
		}

		public ComponentRestrictionsSerializable Serialize()
		{
			var serializable = new ComponentRestrictionsSerializable();
			if (可用舰船等级 == null || 可用舰船等级.Length == 0)
			    serializable.ShipSizes = null;
			else
			    serializable.ShipSizes = 可用舰船等级.Select(item => item.Value).ToArray();
			serializable.NotForOrganicShips = 生物船不可用;
			serializable.NotForMechanicShips = 机械船不可用;
			serializable.UniqueComponentTag = 唯一组件标签;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public ValueWrapper<SizeClass>[] 可用舰船等级;
		public bool 生物船不可用;
		public bool 机械船不可用;
		public string 唯一组件标签;

		public static ComponentRestrictions DefaultValue { get; private set; }
	}
}
