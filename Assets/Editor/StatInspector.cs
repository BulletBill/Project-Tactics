using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(Stat))]
public class StatInspector : PropertyDrawer {

	//	public override void OnInspectorGUI() {
	//		base.OnInspectorGUI();
	//Stat drawnStat = target;

	//string labelValue = drawnStat.SlidingValue.ToString() + " / " + drawnStat.FinalValue.ToString() + " (" + drawnStat.BaseValue.ToString() + ")";
	//EditorGUILayout.LabelField(drawnStat.Name, labelValue);
	//	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

		EditorGUI.BeginProperty(position, label, property);

		// Draw var name label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Don't indent child labels
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		// Make some space for the variables
		var SlideRect = new Rect(position.x, position.y, 30, position.height);
		var TotalRect = new Rect(position.x + 35, position.y, 50, position.height);
		var BaseRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw the fields with the correct data
		string SlideValue = property.FindPropertyRelative("SlidingValue").floatValue.ToString();
		string TotalValue = "/ " + property.FindPropertyRelative("FinalValue").floatValue.ToString();
		string BaseValue = "(" + property.FindPropertyRelative("BaseValue").floatValue.ToString() + ")";

		EditorGUI.LabelField(SlideRect, SlideValue);
		EditorGUI.LabelField(TotalRect, TotalValue);
		EditorGUI.LabelField(BaseRect, BaseValue);
		//EditorGUI.PropertyField(BaseRect, property.FindPropertyRelative("BaseValue"), GUIContent.none);

		// Reset the indent back to normal
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
