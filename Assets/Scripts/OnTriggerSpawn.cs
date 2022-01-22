using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTriggerSpawn : MonoBehaviour
{
    public string acceptTag;
    public GameObject prefab;
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(acceptTag))
        {
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
