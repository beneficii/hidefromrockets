using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bully : MonoBehaviour
{
    public static System.Action<Bully> OnDie;
    public static System.Action<Bully> OnSpawn;

    private void Start()
    {
        OnSpawn?.Invoke(this);
    }

    private void OnDestroy()
    {
        OnDie?.Invoke(this);
    }
}
