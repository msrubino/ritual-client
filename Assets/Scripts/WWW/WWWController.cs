using UnityEngine;
using System.Collections;

public class WWWController : MonoBehaviour 
{
    public bool   isLocal;
    
    public string remoteURL;
    public string localURL;
    public string baseURL               { get { return ( isLocal ) ? localURL : remoteURL ; } }

    public string currentRitualRoute;
    public string declareRitualRoute;
    public string joinRoute;
    public string performedRitualRoute;
    public string resetRoute;
    public string ritualResultsRoute;

    public string currentRitualURL    { get { return baseURL + currentRitualRoute; } }
    public string declareRitualURL    { get { return baseURL + declareRitualRoute; } }
    public string joinURL             { get { return baseURL + joinRoute; } }
    public string performedRitualURL  { get { return baseURL + performedRitualRoute; } }
    public string resetURL            { get { return baseURL + resetRoute; } }
    public string ritualResultsURL    { get { return baseURL + ritualResultsRoute; } }
}
