using UnityEngine;
using System.Collections;

public class ScreenSizeCollider : MonoBehaviourBase
{

    public Camera cam;

    public void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    public void Update()
    {
        SetColliderSize();
    }

    private void SetColliderSize()
    {
        float screenHeight = cam.orthographicSize * 2f;
        Cached<BoxCollider2D>().size = new Vector2(cam.aspect * screenHeight, screenHeight);
    }
    
}
