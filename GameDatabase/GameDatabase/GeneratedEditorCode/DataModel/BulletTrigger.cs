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

	public interface I弹头触发器Content
	{
		void Load(BulletTriggerSerializable serializable, Database database);
		void Save(ref BulletTriggerSerializable serializable);
	}

	public partial class 弹头触发器 : IDataAdapter
	{
		partial void OnDataDeserialized(BulletTriggerSerializable serializable, Database database);
		partial void OnDataSerialized(ref BulletTriggerSerializable serializable);

		private static I弹头触发器Content CreateContent(BulletEffectType type)
		{
			switch (type)
			{
				case BulletEffectType.无:
					return new 弹头触发器EmptyContent();
				case BulletEffectType.播放视觉效果:
					return new 弹头触发器_播放视觉效果();
				case BulletEffectType.生成弹头:
					return new 弹头触发器_生成弹头();
				case BulletEffectType.销毁弹头:
					return new 弹头触发器EmptyContent();
				default:
					throw new DatabaseException("弹头触发器: 无效的内容类型 - " + type);
			}
		}

		public 弹头触发器()
		{
			_content = new 弹头触发器EmptyContent();
		}

		public 弹头触发器(BulletTriggerSerializable serializable, Database database)
		{
			触发器类型 = serializable.Condition;
			行为类型 = serializable.EffectType;
			_content = CreateContent(serializable.EffectType);
			_content.Load(serializable, database);

			OnDataDeserialized(serializable, database);
		}

		public BulletTriggerSerializable Serialize()
		{
			var serializable = new BulletTriggerSerializable();
			serializable.VisualEffect = 0;
			serializable.AudioClip = string.Empty;
			serializable.Ammunition = 0;
			serializable.Color = string.Empty;
			serializable.ColorMode = 0;
			serializable.Quantity = 0;
			serializable.Size = 0f;
			serializable.Lifetime = 0f;
			serializable.Cooldown = 0f;
			serializable.RandomFactor = 0f;
			serializable.PowerMultiplier = 0f;
			serializable.MaxNestingLevel = 0;
			_content.Save(ref serializable);
			serializable.Condition = 触发器类型;
			serializable.EffectType = 行为类型;
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

				yield return new Property(this, type.GetField("触发器类型"), DataChangedEvent);
				yield return new Property(this, type.GetField("行为类型"), OnTypeChanged);

				foreach (var item in _content.GetType().GetFields().Where(f => f.IsPublic && !f.IsStatic))
					yield return new Property(_content, item, DataChangedEvent);
			}
		}

		private void OnTypeChanged()
		{
			_content = CreateContent(行为类型);
			DataChangedEvent?.Invoke();
			LayoutChangedEvent?.Invoke();
		}

		private I弹头触发器Content _content;
		public BulletTriggerCondition 触发器类型;
		public BulletEffectType 行为类型;

		public static 弹头触发器 DefaultValue { get; private set; }
	}

	public class 弹头触发器EmptyContent : I弹头触发器Content
	{
		public void Load(BulletTriggerSerializable serializable, Database database) {}
		public void Save(ref BulletTriggerSerializable serializable) {}
	}

	public partial class 弹头触发器_播放视觉效果 : I弹头触发器Content
	{
		partial void OnDataDeserialized(BulletTriggerSerializable serializable, Database database);
		partial void OnDataSerialized(ref BulletTriggerSerializable serializable);

		public void Load(BulletTriggerSerializable serializable, Database database)
		{
			视觉效果 = database.GetVisualEffectId(serializable.VisualEffect);
			音效 = serializable.AudioClip;
			颜色 = Helpers.ColorFromString(serializable.Color);
			颜色模式 = serializable.ColorMode;
			大小 = new NumericValue<float>(serializable.Size, 0f, 100f);
			持续时间 = new NumericValue<float>(serializable.Lifetime, 0f, 1000f);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref BulletTriggerSerializable serializable)
		{
			serializable.VisualEffect = 视觉效果.Value;
			serializable.AudioClip = 音效;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.ColorMode = 颜色模式;
			serializable.Size = 大小.Value;
			serializable.Lifetime = 持续时间.Value;
			OnDataSerialized(ref serializable);
		}

		public ItemId<VisualEffect> 视觉效果 = ItemId<VisualEffect>.Empty;
		public string 音效;
		public System.Drawing.Color 颜色;
		public ColorMode 颜色模式;
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 持续时间 = new NumericValue<float>(0, 0f, 1000f);
	}

	public partial class 弹头触发器_生成弹头 : I弹头触发器Content
	{
		partial void OnDataDeserialized(BulletTriggerSerializable serializable, Database database);
		partial void OnDataSerialized(ref BulletTriggerSerializable serializable);

		public void Load(BulletTriggerSerializable serializable, Database database)
		{
			音效 = serializable.AudioClip;
			生成弹头 = database.GetAmmunitionId(serializable.Ammunition);
			颜色 = Helpers.ColorFromString(serializable.Color);
			颜色模式 = serializable.ColorMode;
			生成数量 = new NumericValue<int>(serializable.Quantity, 0, 1000);
			大小 = new NumericValue<float>(serializable.Size, 0f, 100f);
			冷却 = new NumericValue<float>(serializable.Cooldown, 0f, 1000f);
			随机系数 = new NumericValue<float>(serializable.RandomFactor, 0f, 1f);
			强度乘数 = new NumericValue<float>(serializable.PowerMultiplier, 0f, 1000f);
			最大嵌套层数 = new NumericValue<int>(serializable.MaxNestingLevel, 0, 100);

			OnDataDeserialized(serializable, database);
		}

		public void Save(ref BulletTriggerSerializable serializable)
		{
			serializable.AudioClip = 音效;
			serializable.Ammunition = 生成弹头.Value;
			serializable.Color = Helpers.ColorToString(颜色);
			serializable.ColorMode = 颜色模式;
			serializable.Quantity = 生成数量.Value;
			serializable.Size = 大小.Value;
			serializable.Cooldown = 冷却.Value;
			serializable.RandomFactor = 随机系数.Value;
			serializable.PowerMultiplier = 强度乘数.Value;
			serializable.MaxNestingLevel = 最大嵌套层数.Value;
			OnDataSerialized(ref serializable);
		}

		public string 音效;
		public ItemId<Ammunition> 生成弹头 = ItemId<Ammunition>.Empty;
		public System.Drawing.Color 颜色;
		public ColorMode 颜色模式;
		public NumericValue<int> 生成数量 = new NumericValue<int>(0, 0, 1000);
		public NumericValue<float> 大小 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 冷却 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> 随机系数 = new NumericValue<float>(0, 0f, 1f);
		public NumericValue<float> 强度乘数 = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<int> 最大嵌套层数 = new NumericValue<int>(0, 0, 100);
	}

}

