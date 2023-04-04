using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public event Action<Target> OnDestroyed;
    /*
    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
    */
    public void DestroyTarget()
    {
        OnDestroyed?.Invoke(this);
        OnDestroyed = null; // Remove all event listeners
        Destroy(gameObject);// does this destroy the component only?
    }
}