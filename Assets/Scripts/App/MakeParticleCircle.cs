using UnityEngine;
using System.Collections;

public class MakeParticleCircle : MonoBehaviour 
{
    public Transform particlePrefab;
    public int count = 12;
    public float radius = 5f;

    void Start()
    {
        float angleIncrement = 360f / (float)count;

        for( int i = 0; i < count; i++ )
        {
            Vector3 position = Quaternion.AngleAxis( i * angleIncrement, Vector3.forward ) * Vector3.up * radius;
            Transform newT = transform.InstantiateChild( particlePrefab );
            newT.localPosition = position;
        }
    }
}
