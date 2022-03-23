using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tower))]
public class TowerEditor : Editor
{
    private void OnSceneGUI()
    {
        Tower towerScript = (Tower)target;//Target of the editor

        Handles.color = Color.blue;
        Handles.DrawWireArc(towerScript.transform.position, Vector3.up, Vector3.forward, 360, towerScript.GetAttackRadius);
    }
}
