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
	public partial class Ship
	{
		partial void OnDataDeserialized(ShipSerializable serializable, Database database);
		partial void OnDataSerialized(ref ShipSerializable serializable);


		public Ship(ShipSerializable serializable, Database database)
		{
			Id = new ItemId<Ship>(serializable.Id, serializable.FileName);
			类别 = serializable.ShipCategory;
			名称 = serializable.Name;
			所属势力 = database.GetFactionId(serializable.Faction);
			等级 = serializable.SizeClass;
			图标贴图 = serializable.IconImage;
			图标大小 = new NumericValue<float>(serializable.IconScale, 0.1f, 100f);
			模型贴图 = serializable.ModelImage;
			模型大小 = new NumericValue<float>(serializable.ModelScale, 0.1f, 100f);
			引擎位置 = serializable.EnginePosition;
			引擎颜色 = Helpers.ColorFromString(serializable.EngineColor);
			引擎大小 = new NumericValue<float>(serializable.EngineSize, 0f, 1f);
			引擎列表 = serializable.Engines?.Select(item => new Engine(item, database)).ToArray();
			能量抗性 = new NumericValue<float>(serializable.EnergyResistance, -100f, 100f);
			动能抗性 = new NumericValue<float>(serializable.KineticResistance, -100f, 100f);
			热能抗性 = new NumericValue<float>(serializable.HeatResistance, -100f, 100f);
			再生 = serializable.Regeneration;
			基础重量倍率 = new NumericValue<float>(serializable.BaseWeightModifier, -0.9f, 1000f);
			内置设备列表 = serializable.BuiltinDevices?.Select(id => new Wrapper<Device> { Item = database.GetDeviceId(id) }).ToArray();
			Layout = new Layout(serializable.Layout);
			炮管列表 = serializable.Barrels?.Select(item => new Barrel(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ShipSerializable serializable)
		{
			serializable.ShipCategory = 类别;
			serializable.Name = 名称;
			serializable.Faction = 所属势力.Value;
			serializable.SizeClass = 等级;
			serializable.IconImage = 图标贴图;
			serializable.IconScale = 图标大小.Value;
			serializable.ModelImage = 模型贴图;
			serializable.ModelScale = 模型大小.Value;
			serializable.EnginePosition = 引擎位置;
			serializable.EngineColor = Helpers.ColorToString(引擎颜色);
			serializable.EngineSize = 引擎大小.Value;
			if (引擎列表 == null || 引擎列表.Length == 0)
			    serializable.Engines = null;
			else
			    serializable.Engines = 引擎列表.Select(item => item.Serialize()).ToArray();
			serializable.EnergyResistance = 能量抗性.Value;
			serializable.KineticResistance = 动能抗性.Value;
			serializable.HeatResistance = 热能抗性.Value;
			serializable.Regeneration = 再生;
			serializable.BaseWeightModifier = 基础重量倍率.Value;
			if (内置设备列表 == null || 内置设备列表.Length == 0)
			    serializable.BuiltinDevices = null;
			else
			    serializable.BuiltinDevices = 内置设备列表.Select(wrapper => wrapper.Item.Value).ToArray();
			serializable.Layout = Layout.Data;
			if (炮管列表 == null || 炮管列表.Length == 0)
			    serializable.Barrels = null;
			else
			    serializable.Barrels = 炮管列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Ship> Id;

		public ShipCategory 类别;
		public string 名称;
		public ItemId<Faction> 所属势力 = ItemId<Faction>.Empty;
		public SizeClass 等级;
		public string 图标贴图;
		public NumericValue<float> 图标大小 = new NumericValue<float>(0, 0.1f, 100f);
		public string 模型贴图;
		public NumericValue<float> 模型大小 = new NumericValue<float>(0, 0.1f, 100f);
		public Vector2 引擎位置;
		public System.Drawing.Color 引擎颜色;
		public NumericValue<float> 引擎大小 = new NumericValue<float>(0, 0f, 1f);
		public Engine[] 引擎列表;
		public NumericValue<float> 能量抗性 = new NumericValue<float>(0, -100f, 100f);
		public NumericValue<float> 动能抗性 = new NumericValue<float>(0, -100f, 100f);
		public NumericValue<float> 热能抗性 = new NumericValue<float>(0, -100f, 100f);
		public bool 再生;
		public NumericValue<float> 基础重量倍率 = new NumericValue<float>(0, -0.9f, 1000f);
		public Wrapper<Device>[] 内置设备列表;
		public Layout Layout;
		public Barrel[] 炮管列表;

		public static Ship DefaultValue { get; private set; }
	}
}
