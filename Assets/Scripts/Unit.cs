using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour, IRocketTarget
{
    public HealthComponent hp;

    private void Awake()
    {
        hp.Init();
        hp.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        Destroy(gameObject);
    }

    public void Damage(int value)
    {
        hp.Remove(value);
    }
}
