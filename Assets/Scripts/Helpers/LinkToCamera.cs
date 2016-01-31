using UnityEngine;

public class LinkToCamera : MonoBehaviour {
    Transform _originalParent;
    Vector3 _originalLocal;

    void OnEnable() 
    {
        _originalParent = transform.parent;
        _originalLocal = transform.localPosition;

        Vector3 camPos = Camera.main.transform.position;

        transform.SetParent( Camera.main.transform );
        transform.localScale = Vector3.one;

        Vector3 pos = transform.position;
        transform.position = new Vector3(camPos.x - pos.x, camPos.y - pos.y, camPos.z + 50);
    }

    void OnDisable() 
    {
        transform.SetParent( _originalParent );
        transform.localPosition = _originalLocal;
        transform.localScale = Vector3.one;
    }
}
