using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CabinetManagerComponent))]
[CanEditMultipleObjects]
public class allCabine : Editor
{

    
    SerializedProperty cabinets;
    SerializedProperty lengths;
//    SerializedProperty canUseHave;
    bool butor, butor2 ;


	void OnEnable()
    {

        cabinets = serializedObject.FindProperty("cabinets");
        lengths = serializedObject.FindProperty("lengths");
//        canUseHave = serializedObject.FindProperty("canUseHave");


    }
    public override void OnInspectorGUI()
    {
        //base.DrawDefaultInspector ();


        serializedObject.Update();

        if ( lengths.arraySize == cabinets.arraySize)
        {
            for (int i = 0; i < cabinets.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 45;
                EditorGUILayout.PropertyField(cabinets.GetArrayElementAtIndex(i), new GUIContent("柜子" + i + ":"));

                GUILayout.FlexibleSpace();
                //GoodType t = new GoodType();
                //object tObj = EditorGUILayout.EnumPopup(t);
                //if (tObj != null&&(int)(tObj)!=0) {
                //    if (canUseHave.GetArrayElementAtIndex(i).stringValue.Length > 0) {
                //        canUseHave.GetArrayElementAtIndex(i).stringValue += ",";
                //    }
                //        canUseHave.GetArrayElementAtIndex(i).stringValue += (int)(tObj);
                //}
               // EditorGUILayout.PropertyField(canUseHave.GetArrayElementAtIndex(i), new GUIContent("物品编号："));
                //int selectedSize = 1;
                //string[] names = new string[] { "Normal", "Double", "Quadruple" };
                //int[] sizes = { 1, 2, 4 };
               // EditorGUILayout.IntPopup("Resize Scale: ", selectedSize, names, sizes);


                EditorGUILayout.PropertyField(lengths.GetArrayElementAtIndex(i), new GUIContent("拉出长度："));
                //EditorGUILayout.BeginToggleGroup ("true or false", b.boolValue);
                bool tempBool = GUILayout.Button("拉"); //EditorGUILayout.DropdownButton(new GUIContent(""), FocusType.Keyboard);
                if (tempBool) {

                CabinetManagerComponent.instance.testTodo(i,true);
                }

                bool tempBool2 = GUILayout.Button("推"); //EditorGUILayout.DropdownButton(new GUIContent(""), FocusType.Keyboard);
                if (tempBool2)
                {

                    CabinetManagerComponent.instance.testTodo(i,false);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.BeginHorizontal();
            butor = EditorGUILayout.DropdownButton(new GUIContent("++"), FocusType.Keyboard);
            butor2 = EditorGUILayout.DropdownButton(new GUIContent("--"), FocusType.Keyboard);
            EditorGUILayout.EndHorizontal();

            if (butor == true)
            {

                cabinets.arraySize += 1;
                lengths.arraySize += 1;

            }
            if (butor2 == true)
            {

                cabinets.arraySize -= 1;
                lengths.arraySize -= 1;

            }

            serializedObject.ApplyModifiedProperties();

        }


    }
}