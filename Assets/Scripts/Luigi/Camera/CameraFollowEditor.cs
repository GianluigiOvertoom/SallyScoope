using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cf = (CameraFollow)target;
        if (GUILayout.Button("Set min CamPos"))
        {
            cf.SetMinCamPos();
        }
        if (GUILayout.Button("Set max CamPos"))
        {
            cf.SetMaxCamPos();
        }
    }
}
