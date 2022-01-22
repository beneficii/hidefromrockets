using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IRocketTarget
{
    public Rocket prefabRocket;
    public List<Transform> rocketSpawnPoints;

    [SerializeField] float shootRate;
    public float ShootRate
    {
        get => shootRate;
        set
        {
            shootRate = value;
            if(rocketCooldown == null)
            {
                rocketCooldown = new CooldownComponent(value);
            }
            else
            {
                rocketCooldown.Cooldown = value;
            }
        }
    }

    CooldownComponent rocketCooldown;

    private void Start()
    {
        ShootRate = 4f;
    }
    
    void HandleDeath()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if(rocketCooldown.Use())
        {
            Instantiate(prefabRocket, rocketSpawnPoints.Rand().position, Quaternion.identity);
        }
    }

    public void Damage(int value)
    {
        // maybe later something
    }
}
