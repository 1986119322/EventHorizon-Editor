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

	public interface I节点Content
	{
		void Load(NodeSerializable serializable, Database database);
		void Save(ref NodeSerializable serializable);
	}

	public partial class 节点 : IDataAdapter
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		private static I节点Content CreateContent(NodeType type)
		{
			switch (type)
			{
				case NodeType.未定义:
					return new 节点EmptyContent();
				case NodeType.即将到来:
					return new 节点EmptyContent();
				case NodeType.显示对话:
					return new 节点_显示对话();
				case NodeType.打开船坞:
					return new 节点_打开船坞();
				case NodeType.条件:
					return new 节点_条件();
				case NodeType.随机:
					return new 节点_随机();
				case NodeType.状态:
					return new 节点_状态();
				case NodeType.攻击舰队:
					return new 节点_攻击舰队();
				case NodeType.攻击星系敌人:
					return new 节点_攻击星系敌人();
				case NodeType.摧毁星系敌人:
					return new 节点_摧毁星系敌人();
				case NodeType.压制星系敌人:
					return new 节点_压制星系敌人();
				case NodeType.撤退:
					return new 节点_撤退();
				case NodeType.接收物品:
					return new 节点_接收物品();
				case NodeType.移除物品:
					return new 节点_移除物品();
				case NodeType.交易:
					return new 节点_交易();
				case NodeType.完成任务:
					return new 节点EmptyContent();
				case NodeType.失败任务:
					return new 节点EmptyContent();
				case NodeType.取消任务:
					return new 节点EmptyContent();
				case NodeType.开始任务:
					return new 节点_开始任务();
				case NodeType.设置角色好感:
					return new 节点_设置角色好感();
				case NodeType.设置势力声望:
					return new 节点_设置势力声望();
				case NodeType.更改角色好感:
					return new 节点_更改角色好感();
				case NodeType.更改势力声望:
					return new 节点_更改势力声望();
				case NodeType.占领空间站:
					return new 节点_占领空间站();
				case NodeType.解放空间站:
					return new 节点_解放空间站();
				case NodeType.更改星区势力:
					return new 节点_更改星区势力();
				default:
					throw new DatabaseException("节点: 无效的内容类型 - " + type);
			}
		}

		public 节点()
		{
			_content = new 节点EmptyContent();
		}

		public 节点(NodeSerializable serializable, Database database)
		{
			Id = new NumericValue<int>(serializable.Id, 1, 999999);
			类型 = serializable.Type;
			_content = CreateContent(serializable.Type);
			_content.Load(serializable, database);

			OnDataDeserialized(serializable, database);
		}

		public NodeSerializable Serialize()
		{
			var serializable = new NodeSerializable();
			serializable.RequiredView = 0;
			serializable.Message = string.Empty;
			serializable.DefaultTransition = 0;
			serializable.DefaultTransition = 0;
			serializable.DefaultTransition = 0;
			serializable.FailureTransition = 0;
			serializable.Enemy = 0;
			serializable.Loot = 0;
			serializable.Quest = 0;
			serializable.Character = 0;
			serializable.Faction = 0;
			serializable.Value = 0;
			serializable.Value = 0;
			serializable.Actions = null;
			serializable.Transitions = null;
			_content.Save(ref serializable);
			serializable.Id = Id.Value;
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

				yield return new Property(this, type.GetField("Id"), DataChangedEvent);
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

		private I节点Content _content;
		public NumericValue<int> Id = new NumericValue<int>(0, 1, 999999);
		public NodeType 类型;

		public static 节点 DefaultValue { get; private set; }
	}

	public class 节点EmptyContent : I节点Content
	{
		public void Load(NodeSerializable serializable, Database database) {}
		public void Save(ref NodeSerializable serializable) {}
	}

	public partial class 节点_显示对话 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			请求视图 = serializable.RequiredView;
			信息 = serializable.Message;
			敌人 = database.GetFleetId(serializable.Enemy);
			物品列表 = database.GetLootId(serializable.Loot);
			角色 = database.GetCharacterId(serializable.Character);
			按钮 = serializable.Actions?.Select(item => new NodeAction(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.RequiredView = 请求视图;
			serializable.Message = 信息;
			serializable.Enemy = 敌人.Value;
			serializable.Loot = 物品列表.Value;
			serializable.Character = 角色.Value;
			if (按钮 == null || 按钮.Length == 0)
			    serializable.Actions = null;
			else
			    serializable.Actions = 按钮.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public RequiredViewMode 请求视图;
		public string 信息;
		public ItemId<Fleet> 敌人 = ItemId<Fleet>.Empty;
		public ItemId<LootModel> 物品列表 = ItemId<LootModel>.Empty;
		public ItemId<Character> 角色 = ItemId<Character>.Empty;
		public NodeAction[] 按钮;
	}

	public partial class 节点_打开船坞 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			势力 = database.GetFactionId(serializable.Faction);
			船坞等级 = new NumericValue<int>(serializable.Value, 0, 10000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Faction = 势力.Value;
			serializable.Value = 船坞等级.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<Faction> 势力 = ItemId<Faction>.Empty;
		public NumericValue<int> 船坞等级 = new NumericValue<int>(0, 0, 10000);
	}

	public partial class 节点_条件 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			信息 = serializable.Message;
			默认跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 0, 999999);
			跳转节点 = serializable.Transitions?.Select(item => new NodeTransition(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.Message = 信息;
			serializable.DefaultTransition = 默认跳转节点.Value;
			if (跳转节点 == null || 跳转节点.Length == 0)
			    serializable.Transitions = null;
			else
			    serializable.Transitions = 跳转节点.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public string 信息;
		public NumericValue<int> 默认跳转节点 = new NumericValue<int>(0, 0, 999999);
		public NodeTransition[] 跳转节点;
	}

	public partial class 节点_随机 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			信息 = serializable.Message;
			默认跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 0, 999999);
			跳转节点 = serializable.Transitions?.Select(item => new NodeTransition(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.Message = 信息;
			serializable.DefaultTransition = 默认跳转节点.Value;
			if (跳转节点 == null || 跳转节点.Length == 0)
			    serializable.Transitions = null;
			else
			    serializable.Transitions = 跳转节点.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public string 信息;
		public NumericValue<int> 默认跳转节点 = new NumericValue<int>(0, 0, 999999);
		public NodeTransition[] 跳转节点;
	}

	public partial class 节点_状态 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			信息 = serializable.Message;
			跳转节点 = serializable.Transitions?.Select(item => new NodeTransition(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.Message = 信息;
			if (跳转节点 == null || 跳转节点.Length == 0)
			    serializable.Transitions = null;
			else
			    serializable.Transitions = 跳转节点.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public string 信息;
		public NodeTransition[] 跳转节点;
	}

	public partial class 节点_攻击舰队 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			胜利跳转 = new NumericValue<int>(serializable.DefaultTransition, 1, 999999);
			失败跳转 = new NumericValue<int>(serializable.FailureTransition, 1, 999999);
			敌人 = database.GetFleetId(serializable.Enemy);
			物品列表 = database.GetLootId(serializable.Loot);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 胜利跳转.Value;
			serializable.FailureTransition = 失败跳转.Value;
			serializable.Enemy = 敌人.Value;
			serializable.Loot = 物品列表.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 胜利跳转 = new NumericValue<int>(0, 1, 999999);
		public NumericValue<int> 失败跳转 = new NumericValue<int>(0, 1, 999999);
		public ItemId<Fleet> 敌人 = ItemId<Fleet>.Empty;
		public ItemId<LootModel> 物品列表 = ItemId<LootModel>.Empty;
	}

	public partial class 节点_攻击星系敌人 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			胜利跳转 = new NumericValue<int>(serializable.DefaultTransition, 1, 999999);
			失败跳转 = new NumericValue<int>(serializable.FailureTransition, 1, 999999);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 胜利跳转.Value;
			serializable.FailureTransition = 失败跳转.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 胜利跳转 = new NumericValue<int>(0, 1, 999999);
		public NumericValue<int> 失败跳转 = new NumericValue<int>(0, 1, 999999);
	}

	public partial class 节点_摧毁星系敌人 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
	}

	public partial class 节点_压制星系敌人 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
	}

	public partial class 节点_撤退 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
	}

	public partial class 节点_接收物品 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			物品列表 = database.GetLootId(serializable.Loot);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Loot = 物品列表.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<LootModel> 物品列表 = ItemId<LootModel>.Empty;
	}

	public partial class 节点_移除物品 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			物品列表 = database.GetLootId(serializable.Loot);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Loot = 物品列表.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<LootModel> 物品列表 = ItemId<LootModel>.Empty;
	}

	public partial class 节点_交易 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			物品列表 = database.GetLootId(serializable.Loot);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Loot = 物品列表.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<LootModel> 物品列表 = ItemId<LootModel>.Empty;
	}

	public partial class 节点_开始任务 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			任务 = database.GetQuestId(serializable.Quest);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Quest = 任务.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<QuestModel> 任务 = ItemId<QuestModel>.Empty;
	}

	public partial class 节点_设置角色好感 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			角色 = database.GetCharacterId(serializable.Character);
			好感度 = new NumericValue<int>(serializable.Value, -100, 100);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Character = 角色.Value;
			serializable.Value = 好感度.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<Character> 角色 = ItemId<Character>.Empty;
		public NumericValue<int> 好感度 = new NumericValue<int>(0, -100, 100);
	}

	public partial class 节点_设置势力声望 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			好感度 = new NumericValue<int>(serializable.Value, -100, 100);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Value = 好感度.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public NumericValue<int> 好感度 = new NumericValue<int>(0, -100, 100);
	}

	public partial class 节点_更改角色好感 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			角色 = database.GetCharacterId(serializable.Character);
			好感度 = new NumericValue<int>(serializable.Value, -100, 100);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Character = 角色.Value;
			serializable.Value = 好感度.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<Character> 角色 = ItemId<Character>.Empty;
		public NumericValue<int> 好感度 = new NumericValue<int>(0, -100, 100);
	}

	public partial class 节点_更改势力声望 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			好感度 = new NumericValue<int>(serializable.Value, -100, 100);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Value = 好感度.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public NumericValue<int> 好感度 = new NumericValue<int>(0, -100, 100);
	}

	public partial class 节点_占领空间站 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
	}

	public partial class 节点_解放空间站 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
	}

	public partial class 节点_更改星区势力 : I节点Content
	{
		partial void OnDataDeserialized(NodeSerializable serializable, Database database);
		partial void OnDataSerialized(ref NodeSerializable serializable);

		public void Load(NodeSerializable serializable, Database database)
		{
			跳转节点 = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
			势力 = database.GetFactionId(serializable.Faction);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref NodeSerializable serializable)
		{
			serializable.DefaultTransition = 跳转节点.Value;
			serializable.Faction = 势力.Value;
			OnDataSerialized(ref serializable);
		}

		public NumericValue<int> 跳转节点 = new NumericValue<int>(0, 1, 1000);
		public ItemId<Faction> 势力 = ItemId<Faction>.Empty;
	}

}

