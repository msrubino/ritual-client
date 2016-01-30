using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public class ScriptableObjectInstantiator : EditorWindow
{

    private string _path = "Assets/Resources/MyInstance.asset";
    private Type[] _types;
    private string[] _typeNames;
    private int _typeIndex;

    [MenuItem("Window/ScriptableObjectInstantiator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ScriptableObjectInstantiator));
    }

    public void OnGUI()
    {

        _path = EditorGUILayout.TextField("Path:", _path);

        if (GUILayout.Button("Find Scriptable Objects")) 
        {
            FindScriptableObjects();
        }
        if (_typeNames != null) {
            _typeIndex = EditorGUILayout.Popup("Scriptable Objects", _typeIndex, _typeNames);
        }
        if (GUILayout.Button("Create Instance")) 
        {
            CreateAsset();
        }
    }   

    private void FindScriptableObjects()
    {
        var guids = AssetDatabase.FindAssets("t:script");
        var names  = new List<string>();
        var types  = new List<Type>();
        for (int i = 0; i < guids.Length; i++) 
        {
            var guid = guids[i];
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var obj = AssetDatabase.LoadAssetAtPath(path, typeof(MonoScript)) as MonoScript;
            if (obj != null) {
                var type = obj.GetClass();
                if (type != null && type.IsSubclassOf(typeof(ScriptableObject))) {
                    names.Add(type.ToString());
                    types.Add(type);
                }
            }
        }
        _typeNames = names.ToArray();
        _types = types.ToArray();
    }

    private void CreateAsset()
    {
        if (_types == null || _types.Length == 0) return;
        var type = _types[_typeIndex];
        var asset = ScriptableObject.CreateInstance(type);
        AssetDatabase.CreateAsset(asset, _path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

}
