using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using UnityEngine;


// Following along with this video: https://www.youtube.com/watch?app=desktop&v=h8ZAOWY_5LA

// This is a generic/abstract class which the concrete EventChannel classes inherit from
// This inherits from ScriptableObject because the channel scripts act on ScriptableObjects

public abstract class EventChannel<T> : ScriptableObject
{

    readonly HashSet<EventListener<T>> observers = new();

    public void Invoke(T value)
    {
        foreach (var observer in observers)
            {
            observer.Raise(value);
        }
    }

    public void Register(EventListener<T> observer)
    {
        observers.Add(observer);
    }

    public void Deregister(EventListener<T> observer)
    {
        observers.Remove(observer);
    }


}
