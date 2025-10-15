using System.Collections.Generic;
using UnityEngine;

public class Blackboard
{
    private Dictionary<string, object> data = new();
    
    public void Set<T>(string key, T value)
    {
        data.Add(key, value);
    }

    public T Get<T>(string key)
    {
        if (data.TryGetValue(key, out var value))
        {
            return (T)value;
        }
        return default(T);
    }
}
