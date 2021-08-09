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
	public partial class Engine
	{
		partial void OnDataDeserialized(EngineSerializable serializable, Database database);
		partial void OnDataSerialized(ref EngineSerializable serializable);

		public Engine() {}

		public Engine(EngineSerializable serializable, Database database)
		{
			位置 = serializable.Position;
			大小 = new NumericValue<float>(serializable.Size, 0f, 1f);

			OnDataDeserialized(serializable, database);
		}

		public EngineSerializable Serialize()
		{
			var serializable = new EngineSerializable();
			serializable.Position = 位置;
			serializable.Size = 大小.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public Vector2 位置;
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0f, 1f);

		public static Engine DefaultValue { get; private set; }
	}
}
