using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Monster))]
public class MonsterEditor : Editor 
{
    Monster monsterScript;
    bool visableRange = false;
    bool transitionRange = false;
    bool spawnTypes = false;

    void Awake()
    {
        monsterScript = (Monster)target;
    }

    public override void OnInspectorGUI()
    {
        visableRange = EditorGUILayout.Foldout(visableRange, "Visibilty Settings");
        if (visableRange)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.Toggle("Variable Visible Time?", monsterScript.VariableVisibleTime);
            if (monsterScript.VariableVisibleTime)
            {
                EditorGUILayout.LabelField("Maximum - Minimum Time");
                EditorGUILayout.BeginHorizontal();

                monsterScript.VisibleTimeMax = EditorGUILayout.FloatField(monsterScript.VisibleTimeMax);
                monsterScript.VisibleTimeMin = EditorGUILayout.FloatField(monsterScript.VisibleTimeMin);

                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Visible Time:");
                monsterScript.VisibleTimeMax = EditorGUILayout.FloatField(monsterScript.VisibleTimeMax);
            }
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        transitionRange = EditorGUILayout.Foldout(transitionRange, "Transition Settings");
        if (transitionRange)
        {
            EditorGUI.indentLevel++;
            monsterScript.VariableTransitionTime = EditorGUILayout.Toggle("Variable Transition Time? ", monsterScript.VariableTransitionTime);

            if (monsterScript.VariableTransitionTime)
            {
                EditorGUILayout.LabelField("Max - Min Transition Time");
                EditorGUILayout.BeginHorizontal();

                monsterScript.TransitionTimeMax = EditorGUILayout.FloatField(monsterScript.TransitionTimeMax);
                monsterScript.TransitionTimeMin = EditorGUILayout.FloatField(monsterScript.TransitionTimeMin);

                EditorGUILayout.EndHorizontal();
            }
            else 
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PrefixLabel("Transition Time:");
                monsterScript.TransitionTimeMax = EditorGUILayout.FloatField(monsterScript.TransitionTimeMax);

                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        spawnTypes = EditorGUILayout.Foldout(spawnTypes, "Spawn Settings");
        if (spawnTypes)
        {
            EditorGUI.indentLevel++;
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("possibleTypes"), true);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        monsterScript.PointWorth = EditorGUILayout.IntField("Point(s) worth ", monsterScript.PointWorth);

        serializedObject.ApplyModifiedProperties();

    }


}
