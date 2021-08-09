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
	public partial class BulletPrefab
	{
		partial void OnDataDeserialized(BulletPrefabSerializable serializable, Database database);
		partial void OnDataSerialized(ref BulletPrefabSerializable serializable);


		public BulletPrefab(BulletPrefabSerializable serializable, Database database)
		{
			Id = new ItemId<BulletPrefab>(serializable.Id, serializable.FileName);
			子弹形态 = serializable.Shape;
			贴图 = serializable.Image;
			贴图大小 = new NumericValue<float>(serializable.Size, 0.01f, 100f);
			效果偏移距离 = new NumericValue<float>(serializable.Margins, 0f, 1f);
			主要颜色 = Helpers.ColorFromString(serializable.MainColor);
			主要颜色模式 = serializable.MainColorMode;
			次要颜色 = Helpers.ColorFromString(serializable.SecondColor);
			次要颜色模式 = serializable.SecondColorMode;

			OnDataDeserialized(serializable, database);
		}

		public void Save(BulletPrefabSerializable serializable)
		{
			serializable.Shape = 子弹形态;
			serializable.Image = 贴图;
			serializable.Size = 贴图大小.Value;
			serializable.Margins = 效果偏移距离.Value;
			serializable.MainColor = Helpers.ColorToString(主要颜色);
			serializable.MainColorMode = 主要颜色模式;
			serializable.SecondColor = Helpers.ColorToString(次要颜色);
			serializable.SecondColorMode = 次要颜色模式;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<BulletPrefab> Id;

		public BulletShape 子弹形态;
		public string 贴图;
		public NumericValue<float> 贴图大小 = new NumericValue<float>(0, 0.01f, 100f);
		public NumericValue<float> 效果偏移距离 = new NumericValue<float>(0, 0f, 1f);
		public System.Drawing.Color 主要颜色;
		public ColorMode 主要颜色模式;
		public System.Drawing.Color 次要颜色;
		public ColorMode 次要颜色模式;

		public static BulletPrefab DefaultValue { get; private set; }
	}
}
