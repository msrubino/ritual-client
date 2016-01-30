using UnityEngine;
using System.Collections;

public class WWWController : MonoBehaviour 
{
    public string baseURL;
    public string joinRoute;

    public string joinURL { get { return baseURL + joinRoute; } }
}
