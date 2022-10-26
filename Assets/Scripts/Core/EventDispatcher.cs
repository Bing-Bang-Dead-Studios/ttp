using System;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher
{
    private EventDispatcher() { }

    /// <summary>
    /// currently registered events.
    /// </summary>
    private readonly Dictionary<string, Dictionary<string, Action>> _events = new Dictionary<string, Dictionary<string, Action>>();

    /// <summary>
    /// Gets the currently active eventDispatcher instance.
    /// </summary>
    public static EventDispatcher Instance { get; private set; }

    /// <summary>
    /// Initalizes the Event Dispatcher with a new instance.
    /// </summary>
    public static void Initiailze()
    {
        Instance = new EventDispatcher();
    }

    /// <summary>
    /// Invoke callback for events
    /// </summary>
    /// <typeparam name="T">The type of the event to lookup.</typeparam>
    public void Invoke<T>() where T : IEvent
    {
        string key = typeof(T).Name;
        if (!_events.ContainsKey(key))
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        foreach(var callback in _events[key])
        {
            callback.Value.Invoke();
        }
    }

    /// <summary>
    /// Registers the service with the current service locator.
    /// </summary>
    /// <typeparam name="T">event type.</typeparam>
    /// <param name="event">event instance.</param>
    public void AddListener<T>(IEventUser callClass, Action callback) where T : IEvent
    {
        string key = typeof(T).Name;
        string className = callClass.GetType().Name;
        if (_events.ContainsKey(key))
        {
            if (_events[key].ContainsKey(className))
            {
                Debug.LogError($"Attempted to register event of type {key} which is already registered with the {GetType().Name}.");
            }
            else
            {
                _events[key].Add(className, callback);
            }
        }
        else
        {
            _events.Add(key, new Dictionary<string, Action>{{className, callback}});
        }
    }

    /// <summary>
    /// Unregisters the event.
    /// </summary>
    /// <typeparam name="T">Service type.</typeparam>
    public void Unregister<T>() where T : IService
    {
        //TODO: Implement unregister!
        string key = typeof(T).Name;
        if (!_events.ContainsKey(key))
        {
            Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        _events.Remove(key);
    }
}