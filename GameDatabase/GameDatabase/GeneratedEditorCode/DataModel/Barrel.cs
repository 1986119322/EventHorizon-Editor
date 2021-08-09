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
	public partial class Barrel
	{
		partial void OnDataDeserialized(BarrelSerializable serializable, Database database);
		partial void OnDataSerialized(ref BarrelSerializable serializable);

		public Barrel() {}

		public Barrel(BarrelSerializable serializable, Database database)
		{
			位置 = serializable.Position;
			初始朝向 = new NumericValue<float>(serializable.Rotation, -360f, 360f);
			发射偏移 = new NumericValue<float>(serializable.Offset, 0f, 1f);
			自瞄类型 = serializable.PlatformType;
			自瞄角度 = new NumericValue<float>(serializable.AutoAimingArc, 0f, 360f);
			旋转速度 = new NumericValue<float>(serializable.RotationSpeed, 0f, 1000f);
			红格类型 = serializable.WeaponClass;
			炮台贴图 = serializable.Image;
			炮台大小 = new NumericValue<float>(serializable.Size, 0f, 100f);

			OnDataDeserialized(serializable, database);
		}

		public BarrelSerializable Serialize()
		{
			var serializable = new BarrelSerializable();
			serializable.Position = 位置;
			serializable.Rotation = 初始朝向.Value;
			serializable.Offset = 发射偏移.Value;
			serializable.PlatformType = 自瞄类型;
			serializable.AutoAimingArc = 自瞄角度.Value;
			serializable.RotationSpeed = 旋转速度.Value;
			serializable.WeaponClass = 红格类型;
			serializable.Image = 炮台贴图;
			serializable.Size = 炮台大小.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public Vector2 位置;
		public NumericValue<float> 初始朝向 = new NumericValue<float>(0, -360f, 360f);
		public NumericValue<float> 发射偏移 = new NumericValue<float>(0, 0f, 1f);
		public PlatformType 自瞄类型;
		public NumericValue<float> 自瞄角度 = new NumericValue<float>(0, 0f, 360f);
		public NumericValue<float> 旋转速度 = new NumericValue<float>(0, 0f, 1000f);
		public string 红格类型;
		public string 炮台贴图;
		public NumericValue<float> 炮台大小 = new NumericValue<float>(0, 0f, 100f);

		public static Barrel DefaultValue { get; private set; }
	}
}
