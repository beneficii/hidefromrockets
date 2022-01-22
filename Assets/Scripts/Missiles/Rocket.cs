using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocket : MonoBehaviour
{
    public string searchTag;
    public float speed = 10f;
    public int damage = 1;

    public GameObject prefabExplosion;

    IRocketTarget target;

    private void Start()
    {
        target = GameObject
            .FindGameObjectWithTag(searchTag)
            ?.GetComponent<IRocketTarget>();
    }

    private void Update()
    {
        if(!FancyUtils.Interfaces.Exists(target))
        {
            Destroy(gameObject);
            return;
        }

        transform.up = target.transform.position - transform.position;
        if (transform.MoveTowards(target.transform.position, Time.deltaTime * speed))
        {
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {
        Destroy(gameObject);
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
    }
}

public interface IRocketTarget
{
    Transform transform { get; }
    void Damage(int value);
}
