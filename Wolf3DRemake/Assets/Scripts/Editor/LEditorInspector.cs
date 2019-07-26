using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelEditor))]
public class LEditorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Clear Editor"))
        {
            LevelEditor editor = (LevelEditor)target;
            editor.ClearEditor();
        }
    }
}
