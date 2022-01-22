using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainingZone : MonoBehaviour
{
    public List<GameObject> toActivate;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach (var item in toActivate)
            {
                item.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
