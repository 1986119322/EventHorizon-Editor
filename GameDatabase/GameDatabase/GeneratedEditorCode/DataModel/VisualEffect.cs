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
	public partial class VisualEffect
	{
		partial void OnDataDeserialized(VisualEffectSerializable serializable, Database database);
		partial void OnDataSerialized(ref VisualEffectSerializable serializable);


		public VisualEffect(VisualEffectSerializable serializable, Database database)
		{
			Id = new ItemId<VisualEffect>(serializable.Id, serializable.FileName);
			元素列表 = serializable.Elements?.Select(item => new VisualEffectElement(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(VisualEffectSerializable serializable)
		{
			if (元素列表 == null || 元素列表.Length == 0)
			    serializable.Elements = null;
			else
			    serializable.Elements = 元素列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<VisualEffect> Id;

		public VisualEffectElement[] 元素列表;

		public static VisualEffect DefaultValue { get; private set; }
	}
}
