using UnityEngine;
using System.Collections;

public class WWWController : MonoBehaviour 
{
    public bool   isLocal;
    
    public string remoteURL;
    public string localURL;
    public string joinRoute;

    public string baseURL { get { return ( isLocal ) ? localURL : remoteURL ; } }
    public string joinURL { get { return baseURL + joinRoute; } }
}
