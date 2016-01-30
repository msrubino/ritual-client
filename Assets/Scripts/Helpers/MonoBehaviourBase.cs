using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MonoBehaviourBase : MonoBehaviour 
{

    private Dictionary<Type,Component> _cachedComponents;

    private GameObject _gameObject;
    public GameObject GameObject
    {
        get
        {
            if (_gameObject == null) _gameObject = gameObject;
            return _gameObject;
        }
    }

    public T Cached<T>() where T : Component
    {
        if (_cachedComponents == null) _cachedComponents = new Dictionary<Type,Component>();
        if (_cachedComponents.ContainsKey(typeof(T))) return (T)_cachedComponents[typeof(T)];
        T component = GetComponent<T>();
        _cachedComponents.Add(typeof(T),component);
        return component;
    }

    protected void Delay(float delay, Action action)
    {
        if (!gameObject.activeSelf) return;
        StartCoroutine(DelayEnumerator(delay, action));
    }

    private IEnumerator DelayEnumerator(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    // Quick References to Key Components
    protected AppController _app      { get { return AppController.Instance; } }
    protected Player        _player   { get { return _app.playerController.Player; } }
    protected WWWController _www      { get { return _app.wwwController; } }
}
