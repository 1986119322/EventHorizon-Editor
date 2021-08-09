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
	public partial class NodeAction
	{
		partial void OnDataDeserialized(NodeActionSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeActionSerializable serializable);

		public NodeAction() {}

		public NodeAction(NodeActionSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.TargetNode, 1, 1000);
			出现条件 = new 条件(serializable.Requirement, database);
			按钮文本 = serializable.ButtonText;

			OnDataDeserialized(serializable, database);
		}

		public NodeActionSerializable Serialize()
		{
			var serializable = new NodeActionSerializable();
			serializable.TargetNode = 跳转节点.Value;
			serializable.Requirement = 出现条件.Serialize();
			serializable.ButtonText = 按钮文本;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public 条件 出现条件 = new 条件();
		public string 按钮文本;

		public static NodeAction DefaultValue { get; private set; }
	}
}
