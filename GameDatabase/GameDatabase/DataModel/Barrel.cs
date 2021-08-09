using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
	public partial class Barrel
	{
        partial void OnDataDeserialized(BarrelSerializable serializable, Database database)
        {
            位置 = new Vector2(serializable.Position.y, serializable.Position.x);
        }

		partial void OnDataSerialized(ref BarrelSerializable serializable)
		{
            serializable.Position = new Vector2(位置.y, 位置.x);
		}
    }
}
