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
	public partial class Component
	{
		partial void OnDataDeserialized(ComponentSerializable serializable, Database database);
		partial void OnDataSerialized(ref ComponentSerializable serializable);


		public Component(ComponentSerializable serializable, Database database)
		{
			Id = new ItemId<Component>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			描述 = serializable.Description;
			显示类别 = serializable.DisplayCategory;
			可获得性 = serializable.Availability;
			基础属性 = database.GetComponentStatsId(serializable.ComponentStatsId);
			if (基础属性.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".基础属性 不能为空");
			所属势力 = database.GetFactionId(serializable.Faction);
			等级 = new NumericValue<int>(serializable.Level, 0, 1000);
			图标 = serializable.Icon;
			颜色 = Helpers.ColorFromString(serializable.Color);
			占格布局 = new Layout(serializable.Layout);
			占格类型 = serializable.CellType;
			设备 = database.GetDeviceId(serializable.DeviceId);
			武器 = database.GetWeaponId(serializable.WeaponId);
			弹头 = database.GetAmmunitionId(serializable.AmmunitionId);
			旧弹头 = database.GetAmmunitionObsoleteId(serializable.AmmunitionId);
			占用红格类型 = serializable.WeaponSlotType;
			无人机坪 = database.GetDroneBayId(serializable.DroneBayId);
			无人机配置 = database.GetShipBuildId(serializable.DroneId);
			安装限制 = new ComponentRestrictions(serializable.Restrictions, database);
			可用附加 = serializable.PossibleModifications?.Select(id => new Wrapper<ComponentMod> { Item = database.GetComponentModId(id) }).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ComponentSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.Description = 描述;
			serializable.DisplayCategory = 显示类别;
			serializable.Availability = 可获得性;
			serializable.ComponentStatsId = 基础属性.Value;
			serializable.Faction = 所属势力.Value;
			serializable.Level = 等级.Value;
			serializable.Icon = 图标;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.Layout = 占格布局.Data;
			serializable.CellType = 占格类型;
			serializable.DeviceId = 设备.Value;
			serializable.WeaponId = 武器.Value;
			serializable.AmmunitionId = 弹头.Value;
			serializable.AmmunitionId = 旧弹头.Value;
			serializable.WeaponSlotType = 占用红格类型;
			serializable.DroneBayId = 无人机坪.Value;
			serializable.DroneId = 无人机配置.Value;
			serializable.Restrictions = 安装限制.Serialize();
			if (可用附加 == null || 可用附加.Length == 0)
			    serializable.PossibleModifications = null;
			else
			    serializable.PossibleModifications = 可用附加.Select(wrapper => wrapper.Item.Value).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Component> Id;

		public string 名称;
		public string 描述;
		public ComponentCategory 显示类别;
		public Availability 可获得性;
		public ItemId<ComponentStats> 基础属性 = ItemId<ComponentStats>.Empty;
		public ItemId<Faction> 所属势力 = ItemId<Faction>.Empty;
		public NumericValue<int> 等级 = new NumericValue<int>(0, 0, 1000);
		public string 图标;
		public System.Drawing.Color 颜色;
		public Layout 占格布局;
		public string 占格类型;
		public ItemId<Device> 设备 = ItemId<Device>.Empty;
		public ItemId<Weapon> 武器 = ItemId<Weapon>.Empty;
		public ItemId<Ammunition> 弹头 = ItemId<Ammunition>.Empty;
		public ItemId<AmmunitionObsolete> 旧弹头 = ItemId<AmmunitionObsolete>.Empty;
		public string 占用红格类型;
		public ItemId<DroneBay> 无人机坪 = ItemId<DroneBay>.Empty;
		public ItemId<ShipBuild> 无人机配置 = ItemId<ShipBuild>.Empty;
		public ComponentRestrictions 安装限制 = new ComponentRestrictions();
		public Wrapper<ComponentMod>[] 可用附加;

		public static Component DefaultValue { get; private set; }
	}
}
