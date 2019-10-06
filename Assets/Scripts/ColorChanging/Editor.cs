using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HueShifter))]
class ColorCyclerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Cycle"))
        {
            HueShifter cycler = (HueShifter)target;
            cycler.Cycle();
        }
    }
}