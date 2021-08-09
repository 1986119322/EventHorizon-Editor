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
	public partial class ImpactEffect
	{
		partial void OnDataDeserialized(ImpactEffectSerializable serializable, Database database);
		partial void OnDataSerialized(ref ImpactEffectSerializable serializable);

		public ImpactEffect() {}

		public ImpactEffect(ImpactEffectSerializable serializable, Database database)
		{
			类型 = serializable.Type;
			伤害类型 = serializable.DamageType;
			效果强度 = new NumericValue<float>(serializable.Power, 0f, 1E+09f);
			强度系数 = new NumericValue<float>(serializable.Factor, 0f, 1f);

			OnDataDeserialized(serializable, database);
		}

		public ImpactEffectSerializable Serialize()
		{
			var serializable = new ImpactEffectSerializable();
			serializable.Type = 类型;
			serializable.DamageType = 伤害类型;
			serializable.Power = 效果强度.Value;
			serializable.Factor = 强度系数.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public ImpactEffectType 类型;
		public DamageType 伤害类型;
		public NumericValue<float> 效果强度 = new NumericValue<float>(0, 0f, 1E+09f);
		public NumericValue<float> 强度系数 = new NumericValue<float>(0, 0f, 1f);

		public static ImpactEffect DefaultValue { get; private set; }
	}
}
