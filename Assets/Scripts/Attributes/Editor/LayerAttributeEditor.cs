using UnityEditor;
using UnityEngine;

namespace MeltdownPrototype
{
	/// <summary>
	/// https://answers.unity.com/questions/609385/type-for-layer-selection.htmlC
	/// </summary>
	[CustomPropertyDrawer(typeof(LayerAttribute))]
	public class LayerAttributeEditor : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// One line of  oxygen free code.
			property.intValue = EditorGUI.LayerField(position, label,  property.intValue);
		}
	}
}