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
	public partial class Ammunition
	{
		partial void OnDataDeserialized(AmmunitionSerializable serializable, Database database);
		partial void OnDataSerialized(ref AmmunitionSerializable serializable);


		public Ammunition(AmmunitionSerializable serializable, Database database)
		{
			Id = new ItemId<Ammunition>(serializable.Id, serializable.FileName);
			弹体 = new BulletBody(serializable.Body, database);
			触发器 = serializable.Triggers?.Select(item => new 弹头触发器(item, database)).ToArray();
			击中方式 = serializable.ImpactType;
			击中效果 = serializable.Effects?.Select(item => new ImpactEffect(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(AmmunitionSerializable serializable)
		{
			serializable.Body = 弹体.Serialize();
			if (触发器 == null || 触发器.Length == 0)
			    serializable.Triggers = null;
			else
			    serializable.Triggers = 触发器.Select(item => item.Serialize()).ToArray();
			serializable.ImpactType = 击中方式;
			if (击中效果 == null || 击中效果.Length == 0)
			    serializable.Effects = null;
			else
			    serializable.Effects = 击中效果.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Ammunition> Id;

		public BulletBody 弹体 = new BulletBody();
		public 弹头触发器[] 触发器;
		public BulletImpactType 击中方式;
		public ImpactEffect[] 击中效果;

		public static Ammunition DefaultValue { get; private set; }
	}
}
