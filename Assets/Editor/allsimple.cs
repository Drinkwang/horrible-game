using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(allsave))]
[CanEditMultipleObjects]
public class allsimple : Editor {
	
	public  GameObject esven;
	private static GameObject even;
	SerializedProperty a;
	SerializedProperty b;
	bool butor,butor2;
	// Use this for initialization
	[MenuItem("exaple/事件系统")]
	static void init()
	{if (even == null)
            GameObject.Instantiate(even);
        else
            Debug.Log("is alreay create!");
	}

	void OnEnable () {
		even = esven;
		a = serializedObject.FindProperty ("a");
		b = serializedObject.FindProperty ("b");
		Debug.Log (a);

		Debug.Log (a.arraySize);

		//print(a.arraySize);
	}
	public override  void OnInspectorGUI(){
		//base.DrawDefaultInspector ();


		serializedObject.Update ();

		if (a.arraySize != 0 && a.arraySize == b.arraySize && b.arraySize != 0) {
			for (int i = 0; i<a.arraySize; i++) {
				EditorGUILayout.BeginHorizontal();
				EditorGUIUtility.labelWidth = 45;
				EditorGUILayout.PropertyField (a.GetArrayElementAtIndex (i), new GUIContent ("事件："));

				GUILayout.FlexibleSpace ();

				EditorGUILayout.PropertyField (b.GetArrayElementAtIndex (i), new GUIContent ("真假："));
				//EditorGUILayout.BeginToggleGroup ("true or false", b.boolValue);
				EditorGUILayout.EndHorizontal ();
			}
			EditorGUILayout.BeginHorizontal ();
			butor = EditorGUILayout.DropdownButton (new GUIContent("++"), FocusType.Keyboard);
			butor2 = EditorGUILayout.DropdownButton (new GUIContent("--"), FocusType.Keyboard);
			EditorGUILayout.EndHorizontal ();
			//Debug.Log (butor);}
		if (butor == true) {
			//a.GetArrayElementAtInde		x (0) =a.GetArrayElementAtIndex(2);
		//	EditorGUILayout.PropertyField (a,new GUIContent ("事件："));
			a.arraySize += 1;
			b.arraySize += 1;
		//	GUILayout.FlexibleSpace ();

		//	EditorGUILayout.PropertyField (b, new GUIContent ("真假："));
		}
			if (butor2 == true) {
				//a.GetArrayElementAtInde		x (0) =a.GetArrayElementAtIndex(2);
				//	EditorGUILayout.PropertyField (a,new GUIContent ("事件："));
				a.arraySize -= 1;
				b.arraySize -= 1;
				//	GUILayout.FlexibleSpace ();

				//	EditorGUILayout.PropertyField (b, new GUIContent ("真假："));
			}
		//EditorGUILayout.BeginScrollView (new Vector2(0,0));
		serializedObject.ApplyModifiedProperties ();

	}
	

}
}