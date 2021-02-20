using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGeneration))]
public class GenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelGeneration lg = (LevelGeneration)target;

        if (GUILayout.Button("Generate Lines"))
        {
            lg.GenerateLines();
        }
    }


}
