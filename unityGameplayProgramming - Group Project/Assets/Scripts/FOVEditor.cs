#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;




[CustomEditor(typeof(FieldOfView))]

public class FOVEditor : Editor
{

    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 FOV_angle_left = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 FOV_angle_right = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        Handles.color = Color.red;
        Handles.DrawLine(fov.transform.position, fov.transform.position + FOV_angle_left * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + FOV_angle_right * fov.radius);

        if (fov.player_in_view)
        {
            Handles.color = Color.yellow;
            Handles.DrawLine(fov.transform.position, fov.player.transform.position);
        }
    }


    private Vector3 DirectionFromAngle(float eulerY, float angle_in_degrees)
    {
        angle_in_degrees += eulerY;

        return new Vector3(Mathf.Sin(angle_in_degrees * Mathf.Deg2Rad), 0, Mathf.Cos(angle_in_degrees * Mathf.Deg2Rad));
    }




}
#endif
