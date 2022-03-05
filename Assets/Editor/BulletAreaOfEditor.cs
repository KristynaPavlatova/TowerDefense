using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BulletAreaOf))]
public class BulletAreaOfEditor : Editor
{
    private void OnSceneGUI()
    {
        BulletAreaOf bulletScript = (BulletAreaOf)target;//Target of the editor

        Handles.color = Color.blue;
        Handles.DrawWireArc(bulletScript.transform.position, Vector3.up, Vector3.forward, 360, bulletScript.GetAreaOfEffectRadius);
    }
}
