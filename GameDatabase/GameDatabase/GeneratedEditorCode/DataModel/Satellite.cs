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
	public partial class Satellite
	{
		partial void OnDataDeserialized(SatelliteSerializable serializable, Database database);
		partial void OnDataSerialized(ref SatelliteSerializable serializable);


		public Satellite(SatelliteSerializable serializable, Database database)
		{
			Id = new ItemId<Satellite>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			模型贴图 = serializable.ModelImage;
			模型大小 = new NumericValue<float>(serializable.ModelScale, 0.1f, 100f);
			可安装等级 = serializable.SizeClass;
			Layout = new Layout(serializable.Layout);
			炮管列表 = serializable.Barrels?.Select(item => new Barrel(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(SatelliteSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.ModelImage = 模型贴图;
			serializable.ModelScale = 模型大小.Value;
			serializable.SizeClass = 可安装等级;
			serializable.Layout = Layout.Data;
			if (炮管列表 == null || 炮管列表.Length == 0)
			    serializable.Barrels = null;
			else
			    serializable.Barrels = 炮管列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Satellite> Id;

		public string 名称;
		public string 模型贴图;
		public NumericValue<float> 模型大小 = new NumericValue<float>(0, 0.1f, 100f);
		public SizeClass 可安装等级;
		public Layout Layout;
		public Barrel[] 炮管列表;

		public static Satellite DefaultValue { get; private set; }
	}
}
