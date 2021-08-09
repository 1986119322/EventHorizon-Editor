//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Linq;
using System.Collections.Generic;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{

	public interface I物品列表Content
	{
		void Load(LootContentSerializable serializable, Database database);
		void Save(ref LootContentSerializable serializable);
	}

	public partial class 物品列表 : IDataAdapter
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		private static I物品列表Content CreateContent(LootItemType type)
		{
			switch (type)
			{
				case LootItemType.无:
					return new 物品列表EmptyContent();
				case LootItemType.一些钱:
					return new 物品列表_一些钱();
				case LootItemType.燃料:
					return new 物品列表_燃料();
				case LootItemType.钱:
					return new 物品列表_钱();
				case LootItemType.星币:
					return new 物品列表_星币();
				case LootItemType.星图:
					return new 物品列表EmptyContent();
				case LootItemType.随机组件:
					return new 物品列表_随机组件();
				case LootItemType.随机物品:
					return new 物品列表_随机物品();
				case LootItemType.所有物品:
					return new 物品列表_所有物品();
				case LootItemType.几率物品:
					return new 物品列表_几率物品();
				case LootItemType.任务物品:
					return new 物品列表_任务物品();
				case LootItemType.带配置飞船:
					return new 物品列表_带配置飞船();
				case LootItemType.空船:
					return new 物品列表_空船();
				case LootItemType.组件:
					return new 物品列表_组件();
				default:
					throw new DatabaseException("物品列表: 无效的内容类型 - " + type);
			}
		}

		public 物品列表()
		{
			_content = new 物品列表EmptyContent();
		}

		public 物品列表(LootContentSerializable serializable, Database database)
		{
			类型 = serializable.Type;
			_content = CreateContent(serializable.Type);
			_content.Load(serializable, database);

			OnDataDeserialized(serializable, database);
		}

		public LootContentSerializable Serialize()
		{
			var serializable = new LootContentSerializable();
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.MinAmount = 0;
			serializable.MaxAmount = 0;
			serializable.ValueRatio = 0f;
			serializable.Factions = new FactionFilterSerializable();
			serializable.Items = null;
			_content.Save(ref serializable);
			serializable.Type = 类型;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public event System.Action LayoutChangedEvent;
		public event System.Action DataChangedEvent;

		public IEnumerable<IProperty> Properties
		{
			get
			{
				var type = GetType();

				yield return new Property(this, type.GetField("类型"), OnTypeChanged);

				foreach (var item in _content.GetType().GetFields().Where(f => f.IsPublic && !f.IsStatic))
					yield return new Property(_content, item, DataChangedEvent);
			}
		}

		private void OnTypeChanged()
		{
			_content = CreateContent(类型);
			DataChangedEvent?.Invoke();
			LayoutChangedEvent?.Invoke();
		}

		private I物品列表Content _content;
		public LootItemType 类型;

		public static 物品列表 DefaultValue { get; private set; }
	}

	public class 物品列表EmptyContent : I物品列表Content
	{
		public void Load(LootContentSerializable serializable, Database database) {}
		public void Save(ref LootContentSerializable serializable) {}
	}

	public partial class 物品列表_一些钱 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			比率 = new NumericValue<float>(serializable.ValueRatio, 0.001f, 1000f);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.ValueRatio = 比率.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<float> 比率 = new NumericValue<float>(0, 0.001f, 1000f);
	}

	public partial class 物品列表_燃料 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
	}

	public partial class 物品列表_钱 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
	}

	public partial class 物品列表_星币 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
	}

	public partial class 物品列表_随机组件 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);
			比率 = new NumericValue<float>(serializable.ValueRatio, 0.001f, 1000f);
			筛选势力 = new RequiredFactions(serializable.Factions, database);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			serializable.ValueRatio = 比率.Value;
			serializable.Factions = 筛选势力.Serialize();
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<float> 比率 = new NumericValue<float>(0, 0.001f, 1000f);
		public RequiredFactions 筛选势力 = new RequiredFactions();
	}

	public partial class 物品列表_随机物品 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);
			物品列表 = serializable.Items?.Select(item => new LootItem(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			if (物品列表 == null || 物品列表.Length == 0)
			    serializable.Items = null;
			else
			    serializable.Items = 物品列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
		public LootItem[] 物品列表;
	}

	public partial class 物品列表_所有物品 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			物品列表 = serializable.Items?.Select(item => new LootItem(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			if (物品列表 == null || 物品列表.Length == 0)
			    serializable.Items = null;
			else
			    serializable.Items = 物品列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public LootItem[] 物品列表;
	}

	public partial class 物品列表_几率物品 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			物品列表 = serializable.Items?.Select(item => new LootItem(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			if (物品列表 == null || 物品列表.Length == 0)
			    serializable.Items = null;
			else
			    serializable.Items = 物品列表.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public LootItem[] 物品列表;
	}

	public partial class 物品列表_任务物品 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			任务物品 = database.GetQuestItemId(serializable.ItemId);
			if (任务物品.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".任务物品 不能为空");
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.ItemId = 任务物品.Value;
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<QuestItem> 任务物品 = ItemId<QuestItem>.Empty;
		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
	}

	public partial class 物品列表_带配置飞船 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			带配置飞船 = database.GetShipBuildId(serializable.ItemId);
			if (带配置飞船.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".带配置飞船 不能为空");

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.ItemId = 带配置飞船.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<ShipBuild> 带配置飞船 = ItemId<ShipBuild>.Empty;
	}

	public partial class 物品列表_空船 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			空船 = database.GetShipId(serializable.ItemId);
			if (空船.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".空船 不能为空");

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.ItemId = 空船.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Ship> 空船 = ItemId<Ship>.Empty;
	}

	public partial class 物品列表_组件 : I物品列表Content
	{
		partial void OnDataDeserialized(LootContentSerializable serializable, Database database);
		partial void OnDataSerialized(ref LootContentSerializable serializable);

		public void Load(LootContentSerializable serializable, Database database)
		{
			组件 = database.GetComponentId(serializable.ItemId);
			if (组件.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".组件 不能为空");
			最小数量 = new NumericValue<int>(serializable.MinAmount, 0, 999999999);
			最大数量 = new NumericValue<int>(serializable.MaxAmount, 0, 999999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref LootContentSerializable serializable)
		{
			serializable.ItemId = 组件.Value;
			serializable.MinAmount = 最小数量.Value;
			serializable.MaxAmount = 最大数量.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Component> 组件 = ItemId<Component>.Empty;
		public NumericValue<int> 最小数量 = new NumericValue<int>(0, 0, 999999999);
		public NumericValue<int> 最大数量 = new NumericValue<int>(0, 0, 999999999);
	}

}

