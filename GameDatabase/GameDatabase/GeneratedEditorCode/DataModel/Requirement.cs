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

	public interface I条件Content
	{
		void Load(RequirementSerializable serializable, Database database);
		void Save(ref RequirementSerializable serializable);
	}

	public partial class 条件 : IDataAdapter
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		private static I条件Content CreateContent(RequirementType type)
		{
			switch (type)
			{
				case RequirementType.空:
					return new 条件EmptyContent();
				case RequirementType.任意:
					return new 条件_任意();
				case RequirementType.所有:
					return new 条件_所有();
				case RequirementType.无一:
					return new 条件_无一();
				case RequirementType.玩家位置:
					return new 条件_玩家位置();
				case RequirementType.移动到任意星系:
					return new 条件_移动到任意星系();
				case RequirementType.攻击性星系敌人:
					return new 条件EmptyContent();
				case RequirementType.任务已完成:
					return new 条件_任务已完成();
				case RequirementType.任务激活中:
					return new 条件_任务激活中();
				case RequirementType.角色好感:
					return new 条件_角色好感();
				case RequirementType.星区声望:
					return new 条件_星区声望();
				case RequirementType.星区已占领:
					return new 条件EmptyContent();
				case RequirementType.势力:
					return new 条件_势力();
				case RequirementType.拥有任务物品:
					return new 条件_拥有任务物品();
				case RequirementType.拥有物品:
					return new 条件_拥有物品();
				case RequirementType.拥有指定物品:
					return new 条件_拥有指定物品();
				case RequirementType.返回任务起始点:
					return new 条件EmptyContent();
				case RequirementType.从任务触发开始进行计时:
					return new 条件_从任务触发开始进行计时();
				case RequirementType.从任务上次完成时开始计时:
					return new 条件_从任务上次完成时开始计时();
				default:
					throw new DatabaseException("条件: 无效的内容类型 - " + type);
			}
		}

		public 条件()
		{
			_content = new 条件EmptyContent();
		}

		public 条件(RequirementSerializable serializable, Database database)
		{
			类型 = serializable.Type;
			_content = CreateContent(serializable.Type);
			_content.Load(serializable, database);

			OnDataDeserialized(serializable, database);
		}

		public RequirementSerializable Serialize()
		{
			var serializable = new RequirementSerializable();
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.MinValue = 0;
			serializable.MaxValue = 0;
			serializable.MinValue = 0;
			serializable.MaxValue = 0;
			serializable.MinValue = 0;
			serializable.MinValue = 0;
			serializable.MaxValue = 0;
			serializable.Character = 0;
			serializable.势力 = 0;
			serializable.Loot = new LootContentSerializable();
			serializable.Requirements = null;
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

		private I条件Content _content;
		public RequirementType 类型;

		public static 条件 DefaultValue { get; private set; }
	}

	public class 条件EmptyContent : I条件Content
	{
		public void Load(RequirementSerializable serializable, Database database) {}
		public void Save(ref RequirementSerializable serializable) {}
	}

	public partial class 条件_任意 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			条件 = serializable.Requirements?.Select(item => new 条件(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			if (条件 == null || 条件.Length == 0)
			    serializable.Requirements = null;
			else
			    serializable.Requirements = 条件.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public 条件[] 条件;
	}

	public partial class 条件_所有 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			条件 = serializable.Requirements?.Select(item => new 条件(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			if (条件 == null || 条件.Length == 0)
			    serializable.Requirements = null;
			else
			    serializable.Requirements = 条件.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public 条件[] 条件;
	}

	public partial class 条件_无一 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			条件 = serializable.Requirements?.Select(item => new 条件(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			if (条件 == null || 条件.Length == 0)
			    serializable.Requirements = null;
			else
			    serializable.Requirements = 条件.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public 条件[] 条件;
	}

	public partial class 条件_玩家位置 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			最小距离 = new NumericValue<int>(serializable.MinValue, 0, 10000);
			最大距离 = new NumericValue<int>(serializable.MaxValue, 0, 10000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.MinValue = 最小距离.Value;
			serializable.MaxValue = 最大距离.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小距离 = new NumericValue<int>(0, 0, 10000);
		public NumericValue<int> 最大距离 = new NumericValue<int>(0, 0, 10000);
	}

	public partial class 条件_移动到任意星系 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			最小距离 = new NumericValue<int>(serializable.MinValue, 0, 10000);
			最大距离 = new NumericValue<int>(serializable.MaxValue, 0, 10000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.MinValue = 最小距离.Value;
			serializable.MaxValue = 最大距离.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小距离 = new NumericValue<int>(0, 0, 10000);
		public NumericValue<int> 最大距离 = new NumericValue<int>(0, 0, 10000);
	}

	public partial class 条件_任务已完成 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			任务 = database.GetQuestId(serializable.ItemId);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.ItemId = 任务.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<QuestModel> 任务 = ItemId<QuestModel>.Empty;
	}

	public partial class 条件_任务激活中 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			任务 = database.GetQuestId(serializable.ItemId);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.ItemId = 任务.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<QuestModel> 任务 = ItemId<QuestModel>.Empty;
	}

	public partial class 条件_角色好感 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			最小好感度 = new NumericValue<int>(serializable.MinValue, -100, 100);
			最大好感度 = new NumericValue<int>(serializable.MaxValue, -100, 100);
			角色 = database.GetCharacterId(serializable.Character);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.MinValue = 最小好感度.Value;
			serializable.MaxValue = 最大好感度.Value;
			serializable.Character = 角色.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小好感度 = new NumericValue<int>(0, -100, 100);
		public NumericValue<int> 最大好感度 = new NumericValue<int>(0, -100, 100);
		public ItemId<Character> 角色 = ItemId<Character>.Empty;
	}

	public partial class 条件_星区声望 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			最小好感度 = new NumericValue<int>(serializable.MinValue, -100, 100);
			最大好感度 = new NumericValue<int>(serializable.MaxValue, -100, 100);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.MinValue = 最小好感度.Value;
			serializable.MaxValue = 最大好感度.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 最小好感度 = new NumericValue<int>(0, -100, 100);
		public NumericValue<int> 最大好感度 = new NumericValue<int>(0, -100, 100);
	}

	public partial class 条件_势力 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			势力 = database.GetFactionId(serializable.势力);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.势力 = 势力.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Faction> 势力 = ItemId<Faction>.Empty;
	}

	public partial class 条件_拥有任务物品 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			任务物品 = database.GetQuestItemId(serializable.ItemId);
			拥有数量 = new NumericValue<int>(serializable.MinValue, 1, 1000000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.ItemId = 任务物品.Value;
			serializable.MinValue = 拥有数量.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<QuestItem> 任务物品 = ItemId<QuestItem>.Empty;
		public NumericValue<int> 拥有数量 = new NumericValue<int>(0, 1, 1000000);
	}

	public partial class 条件_拥有物品 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			物品列表 = new 物品列表(serializable.Loot, database);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.Loot = 物品列表.Serialize();
			OnDataSerialized(ref serializable);
		}

		public 物品列表 物品列表 = new 物品列表();
	}

	public partial class 条件_拥有指定物品 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			物品列表 = database.GetLootId(serializable.ItemId);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.ItemId = 物品列表.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<LootModel> 物品列表 = ItemId<LootModel>.Empty;
	}

	public partial class 条件_从任务触发开始进行计时 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			分钟 = new NumericValue<int>(serializable.MinValue, 0, 999999);
			小时 = new NumericValue<int>(serializable.MaxValue, 0, 999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.MinValue = 分钟.Value;
			serializable.MaxValue = 小时.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 分钟 = new NumericValue<int>(0, 0, 999999);
		public NumericValue<int> 小时 = new NumericValue<int>(0, 0, 999999);
	}

	public partial class 条件_从任务上次完成时开始计时 : I条件Content
	{
		partial void OnDataDeserialized(RequirementSerializable serializable, Database database);
		partial void OnDataSerialized(ref RequirementSerializable serializable);

		public void Load(RequirementSerializable serializable, Database database)
		{
			分钟 = new NumericValue<int>(serializable.MinValue, 0, 999999);
			小时 = new NumericValue<int>(serializable.MaxValue, 0, 999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref RequirementSerializable serializable)
		{
			serializable.MinValue = 分钟.Value;
			serializable.MaxValue = 小时.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 分钟 = new NumericValue<int>(0, 0, 999999);
		public NumericValue<int> 小时 = new NumericValue<int>(0, 0, 999999);
	}

}

