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
	public partial class NodeTransition
	{
		partial void OnDataDeserialized(NodeTransitionSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeTransitionSerializable serializable);

		public NodeTransition() {}

		public NodeTransition(NodeTransitionSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.TargetNode, 1, 1000);
			跳转条件 = new 条件(serializable.Requirement, database);
			比重 = new NumericValue<float>(serializable.Weight, 0f, 1000f);

			OnDataDeserialized(serializable, database);
		}

		public NodeTransitionSerializable Serialize()
		{
			var serializable = new NodeTransitionSerializable();
			serializable.TargetNode = 跳转节点.Value;
			serializable.Requirement = 跳转条件.Serialize();
			serializable.Weight = 比重.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public 条件 跳转条件 = new 条件();
		public NumericValue<float> 比重 = new NumericValue<float>(0, 0f, 1000f);

		public static NodeTransition DefaultValue { get; private set; }
	}
}
