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
	public partial class Weapon
	{
		partial void OnDataDeserialized(WeaponSerializable serializable, Database database);
		partial void OnDataSerialized(ref WeaponSerializable serializable);


		public Weapon(WeaponSerializable serializable, Database database)
		{
			Id = new ItemId<Weapon>(serializable.Id, serializable.FileName);
			类型 = serializable.WeaponClass;
			发射频率 = new NumericValue<float>(serializable.FireRate, 0f, 100f);
			散射角 = new NumericValue<float>(serializable.Spread, 0f, 360f);
			弹夹 = new NumericValue<int>(serializable.Magazine, 0, 999999999);
			控制类型 = serializable.ActivationType;
			发射音效 = serializable.ShotSound;
			充能音效 = serializable.ChargeSound;
			发射效果 = serializable.ShotEffectPrefab;
			按钮贴图 = serializable.ControlButtonIcon;

			OnDataDeserialized(serializable, database);
		}

		public void Save(WeaponSerializable serializable)
		{
			serializable.WeaponClass = 类型;
			serializable.FireRate = 发射频率.Value;
			serializable.Spread = 散射角.Value;
			serializable.Magazine = 弹夹.Value;
			serializable.ActivationType = 控制类型;
			serializable.ShotSound = 发射音效;
			serializable.ChargeSound = 充能音效;
			serializable.ShotEffectPrefab = 发射效果;
			serializable.ControlButtonIcon = 按钮贴图;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Weapon> Id;

		public WeaponClass 类型;
		public NumericValue<float> 发射频率 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 散射角 = new NumericValue<float>(0, 0f, 360f);
		public NumericValue<int> 弹夹 = new NumericValue<int>(0, 0, 999999999);
		public ActivationType 控制类型;
		public string 发射音效;
		public string 充能音效;
		public string 发射效果;
		public string 按钮贴图;

		public static Weapon DefaultValue { get; private set; }
	}
}
