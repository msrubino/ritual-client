using UnityEngine;
using System.Collections;

public class ParentMarker : MonoBehaviour 
{
    
    void OnDrawGizmos () 
    {
        Gizmos.color = Color.blue;
        Vector3 v = transform.position;
        float s = 10f;
        Gizmos.DrawLine (v + Vector3.forward * s, v - Vector3.forward * s);
        Gizmos.DrawLine (v + Vector3.up * s, v - Vector3.up * s);
        Gizmos.DrawLine (v + Vector3.right * s, v - Vector3.right * s);
    }
}