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
	public partial class Skill
	{
		partial void OnDataDeserialized(SkillSerializable serializable, Database database);
		partial void OnDataSerialized(ref SkillSerializable serializable);


		public Skill(SkillSerializable serializable, Database database)
		{
			Id = new ItemId<Skill>(serializable.Id, serializable.FileName);
			名称 = serializable.Name;
			图标 = serializable.Icon;
			描述 = serializable.Description;
			基础需求 = new NumericValue<float>(serializable.BaseRequirement, 0f, 100f);
			每级需求 = new NumericValue<float>(serializable.RequirementPerLevel, 0f, 100f);
			基础价格 = new NumericValue<float>(serializable.BasePrice, 0f, 100f);
			每级价格 = new NumericValue<float>(serializable.PricePerLevel, 0f, 100f);
			最大等级 = new NumericValue<int>(serializable.MaxLevel, 1, 1000);

			OnDataDeserialized(serializable, database);
		}

		public void Save(SkillSerializable serializable)
		{
			serializable.Name = 名称;
			serializable.Icon = 图标;
			serializable.Description = 描述;
			serializable.BaseRequirement = 基础需求.Value;
			serializable.RequirementPerLevel = 每级需求.Value;
			serializable.BasePrice = 基础价格.Value;
			serializable.PricePerLevel = 每级价格.Value;
			serializable.MaxLevel = 最大等级.Value;
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Skill> Id;

		public string 名称;
		public string 图标;
		public string 描述;
		public NumericValue<float> 基础需求 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 每级需求 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 基础价格 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<float> 每级价格 = new NumericValue<float>(0, 0f, 100f);
		public NumericValue<int> 最大等级 = new NumericValue<int>(0, 1, 1000);

		public static Skill DefaultValue { get; private set; }
	}
}
