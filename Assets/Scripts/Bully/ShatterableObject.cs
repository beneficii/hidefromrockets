using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShatterableObject : MonoBehaviour, IRocketTarget
{
    public LayerMask whatIsGround;
    public GameObject prefabExplosion;

    public event System.Action OnFall;

    IEnumerator Start()
    {
        // give it time to init
        yield return new WaitForSeconds(2f);
        InitFall();
    }

    public void InitFall()
    {
        if (OnFall != null) return;

        OnFall += HandleFall;
    }

    void HandleFall()
    {
        Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if we hit the ground
        if ((whatIsGround & (1 << collision.gameObject.layer)) != 0)
        {
            OnFall?.Invoke();
        }
    }

    public void Damage(int value)
    {
        Die();
    }

    void Die()
    {
        if (!this) return;

        Destroy(gameObject);
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
    }
}
