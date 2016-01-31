using UnityEngine;
using UnityEditor;

public static class ClearPlayerPrefs {
    [MenuItem("Debug/Reset")]
    public static void Reset() 
    {
        PlayerPrefs.DeleteAll();
    }
}
