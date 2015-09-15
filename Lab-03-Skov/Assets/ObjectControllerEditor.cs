using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectController))]
public class ObjectControllerEditor : Editor
{
    ObjectController controllerScript;

    void Awake()
    {
        controllerScript = (ObjectController)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty controller = serializedObject.FindProperty("controllerObjects");
        EditorGUILayout.PropertyField(controller);

        if (controller.isExpanded)
        {
            EditorGUILayout.PropertyField(controller.FindPropertyRelative("Array.size"));
            EditorGUI.indentLevel++;
            for (int i = 0; i < controller.arraySize; i++)
            {
                EditorGUILayout.PropertyField(controller.GetArrayElementAtIndex(i));
            }
            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
