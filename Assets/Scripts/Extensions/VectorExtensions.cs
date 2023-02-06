using UnityEngine;

namespace MeltdownPrototype
{
	public static class VectorExtensions
	{
		public static Vector3 CopyWithY(this Vector3 vector3, float newY)
		{
			return new Vector3(vector3.x, newY, vector3.z);
		}
	}
}