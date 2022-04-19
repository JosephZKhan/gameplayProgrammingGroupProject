using System;
using UnityEngine;

[Serializable]
public struct Optional<T>
{

    [SerializeField] private bool enabled;
    [SerializeField] private T time;

    public Optional(T initialValue)
    {
        enabled = true;
        time = initialValue;
    }
    
    /*[SerializeField] private bool respawns = false;
    [SerializeField] private float timeToRespawn = 6.0f;*/

    public bool Enabled => enabled;
    public T Time => time;

    public void toggle(bool newToggle)
    {
        enabled = newToggle;
    }

}