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

	public interface I科技Content
	{
		void Load(TechnologySerializable serializable, Database database);
		void Save(ref TechnologySerializable serializable);
	}

	public partial class 科技 : IDataAdapter
	{
		partial void OnDataDeserialized(TechnologySerializable serializable, Database database);
		partial void OnDataSerialized(ref TechnologySerializable serializable);

		private static I科技Content CreateContent(TechType type)
		{
			switch (type)
			{
				case TechType.组件:
					return new 科技_组件();
				case TechType.飞船:
					return new 科技_飞船();
				case TechType.僚机:
					return new 科技_僚机();
				default:
					throw new DatabaseException("科技: 无效的内容类型 - " + type);
			}
		}

		public 科技()
		{
			_content = new 科技EmptyContent();
		}

		public 科技(TechnologySerializable serializable, Database database)
		{
			Id = new ItemId<科技>(serializable);

			类型 = serializable.Type;
			科技需求 = new NumericValue<int>(serializable.Price, 0, 10000);
			隐藏 = serializable.Hidden;
			特殊 = serializable.Special;
			前置科技 = serializable.Dependencies?.Select(id => new Wrapper<科技> { Item = database.GetTechnologyId(id) }).ToArray();
			_content = CreateContent(serializable.Type);
			_content.Load(serializable, database);

			OnDataDeserialized(serializable, database);
		}

		public void Save(TechnologySerializable serializable)
		{
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.ItemId = 0;
			serializable.Faction = 0;
			_content.Save(ref serializable);
			serializable.Type = 类型;
			serializable.Price = 科技需求.Value;
			serializable.Hidden = 隐藏;
			serializable.Special = 特殊;
			if (前置科技 == null || 前置科技.Length == 0)
			    serializable.Dependencies = null;
			else
			    serializable.Dependencies = 前置科技.Select(wrapper => wrapper.Item.Value).ToArray();
			OnDataSerialized(ref serializable);
		}

		public event System.Action LayoutChangedEvent;
		public event System.Action DataChangedEvent;

		public IEnumerable<IProperty> Properties
		{
			get
			{
				var type = GetType();

				yield return new Property(this, type.GetField("类型"), OnTypeChanged);
				yield return new Property(this, type.GetField("科技需求"), DataChangedEvent);
				yield return new Property(this, type.GetField("隐藏"), DataChangedEvent);
				yield return new Property(this, type.GetField("特殊"), DataChangedEvent);
				yield return new Property(this, type.GetField("前置科技"), DataChangedEvent);

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

		public readonly ItemId<科技> Id;

		private I科技Content _content;
		public TechType 类型;
		public NumericValue<int> 科技需求 = new NumericValue<int>(0, 0, 10000);
		public bool 隐藏;
		public bool 特殊;
		public Wrapper<科技>[] 前置科技;

		public static 科技 DefaultValue { get; private set; }
	}

	public class 科技EmptyContent : I科技Content
	{
		public void Load(TechnologySerializable serializable, Database database) {}
		public void Save(ref TechnologySerializable serializable) {}
	}

	public partial class 科技_组件 : I科技Content
	{
		partial void OnDataDeserialized(TechnologySerializable serializable, Database database);
		partial void OnDataSerialized(ref TechnologySerializable serializable);

		public void Load(TechnologySerializable serializable, Database database)
		{
			组件 = database.GetComponentId(serializable.ItemId);
			if (组件.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".组件 不能为空");
			势力 = database.GetFactionId(serializable.Faction);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref TechnologySerializable serializable)
		{
			serializable.ItemId = 组件.Value;
			serializable.Faction = 势力.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Component> 组件 = ItemId<Component>.Empty;
		public ItemId<Faction> 势力 = ItemId<Faction>.Empty;
	}

	public partial class 科技_飞船 : I科技Content
	{
		partial void OnDataDeserialized(TechnologySerializable serializable, Database database);
		partial void OnDataSerialized(ref TechnologySerializable serializable);

		public void Load(TechnologySerializable serializable, Database database)
		{
			飞船 = database.GetShipId(serializable.ItemId);
			if (飞船.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".飞船 不能为空");

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref TechnologySerializable serializable)
		{
			serializable.ItemId = 飞船.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Ship> 飞船 = ItemId<Ship>.Empty;
	}

	public partial class 科技_僚机 : I科技Content
	{
		partial void OnDataDeserialized(TechnologySerializable serializable, Database database);
		partial void OnDataSerialized(ref TechnologySerializable serializable);

		public void Load(TechnologySerializable serializable, Database database)
		{
			僚机 = database.GetSatelliteId(serializable.ItemId);
			if (僚机.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".僚机 不能为空");
			势力 = database.GetFactionId(serializable.Faction);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref TechnologySerializable serializable)
		{
			serializable.ItemId = 僚机.Value;
			serializable.Faction = 势力.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<Satellite> 僚机 = ItemId<Satellite>.Empty;
		public ItemId<Faction> 势力 = ItemId<Faction>.Empty;
	}

}

