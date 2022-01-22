using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orange : MonoBehaviour
{
    public static System.Action<Orange> OnDie;
    public static System.Action<Orange> OnSpawn;

    private void Start()
    {
        OnSpawn?.Invoke(this);
    }

    private void OnDestroy()
    {
        OnDie?.Invoke(this);
    }
}
