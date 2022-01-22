using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestructableBlock : MonoBehaviour, IRocketTarget
{
    public void Damage(int value)
    {
        Destroy(gameObject);
    }
}
