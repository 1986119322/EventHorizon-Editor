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
	public partial class VisualEffectElement
	{
		partial void OnDataDeserialized(VisualEffectElementSerializable serializable, Database database);
		partial void OnDataSerialized(ref VisualEffectElementSerializable serializable);

		public VisualEffectElement() {}

		public VisualEffectElement(VisualEffectElementSerializable serializable, Database database)
		{
			类型 = serializable.Type;
			贴图 = serializable.Image;
			颜色模式 = serializable.ColorMode;
			颜色 = Helpers.ColorFromString(serializable.Color);
			大小 = new NumericValue<float>(serializable.Size, 0.001f, 100f);
			开始时间 = new NumericValue<float>(serializable.StartTime, 0f, 1000f);
			持续时间 = new NumericValue<float>(serializable.Lifetime, 0f, 1000f);

			OnDataDeserialized(serializable, database);
		}

		public VisualEffectElementSerializable Serialize()
		{
			var serializable = new VisualEffectElementSerializable();
			serializable.Type = 类型;
			serializable.Image = 贴图;
			serializable.ColorMode = 颜色模式;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.Size = 大小.Value;
			serializable.StartTime = 开始时间.Value;
			serializable.Lifetime = 持续时间.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public VisualEffectType 类型;
		public string 贴图;
		public ColorMode 颜色模式;
		public System.Drawing.Color 颜色;
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0.001f, 100f);
		public NumericValue<float> 开始时间 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 持续时间 = new NumericValue<float>(0, 0f, 1000f);

		public static VisualEffectElement DefaultValue { get; private set; }
	}
}
