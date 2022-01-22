using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    public int damage = 1;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IRocketTarget>(out var target))
        {
            target.Damage(damage);
        }
    }
}
