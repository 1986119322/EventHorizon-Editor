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
	public partial class InstalledComponent
	{
		partial void OnDataDeserialized(InstalledComponentSerializable serializable, Database database);
		partial void OnDataSerialized(ref InstalledComponentSerializable serializable);

		public InstalledComponent() {}

		public InstalledComponent(InstalledComponentSerializable serializable, Database database)
		{
			组件 = database.GetComponentId(serializable.ComponentId);
			if (组件.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".组件 不能为空");
			附加属性 = serializable.Modification;
			属性品质 = serializable.Quality;
			锁定 = serializable.Locked;
			X = new NumericValue<int>(serializable.X, -32768, 32767);
			Y = new NumericValue<int>(serializable.Y, -32768, 32767);
			炮管Id = new NumericValue<int>(serializable.BarrelId, 0, 255);
			无人机行为 = new NumericValue<int>(serializable.Behaviour, 0, 10);
			绑定按键 = new NumericValue<int>(serializable.KeyBinding, -10, 10);

			OnDataDeserialized(serializable, database);
		}

		public InstalledComponentSerializable Serialize()
		{
			var serializable = new InstalledComponentSerializable();
			serializable.ComponentId = 组件.Value;
			serializable.Modification = 附加属性;
			serializable.Quality = 属性品质;
			serializable.Locked = 锁定;
			serializable.X = X.Value;
			serializable.Y = Y.Value;
			serializable.BarrelId = 炮管Id.Value;
			serializable.Behaviour = 无人机行为.Value;
			serializable.KeyBinding = 绑定按键.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public ItemId<Component> 组件 = ItemId<Component>.Empty;
		public ComponentModType 附加属性;
		public ModificationQuality 属性品质;
		public bool 锁定;
		public NumericValue<int> X = new NumericValue<int>(0, -32768, 32767);
		public NumericValue<int> Y = new NumericValue<int>(0, -32768, 32767);
		public NumericValue<int> 炮管Id = new NumericValue<int>(0, 0, 255);
		public NumericValue<int> 无人机行为 = new NumericValue<int>(0, 0, 10);
		public NumericValue<int> 绑定按键 = new NumericValue<int>(0, -10, 10);

		public static InstalledComponent DefaultValue { get; private set; }
	}
}
