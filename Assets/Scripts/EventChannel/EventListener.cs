using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Following along with this video: https://www.youtube.com/watch?app=desktop&v=h8ZAOWY_5LA

// This is a generic/abstract class that other eventlisteners can inherit from

// Inherits from Monobehaviour because these scripts attach to GameObjects
public abstract class EventListener<T> : MonoBehaviour
{
    // Channel to listen to
    [SerializeField] EventChannel<T> eventChannel;

    // Event to fire when the channel publishes an event
    [SerializeField] UnityEvent<T> unityEvent;

    protected void Awake()
    {
        // Register the channel this listener should listen to
        eventChannel.Register(observer:this);
    }

    protected void OnDestroy()
    {
        // Deregister the channel
        eventChannel.Deregister(observer: this);
    }

    // Reached this stage at 5 minutes 11 seconds in the video linked above.
    public void Raise(T value)
    {
        // The questions mark is a null check - only invoke the event if the unityEvent is NOT null
        unityEvent?.Invoke(value);
    }

}
