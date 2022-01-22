using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeanSpeaker : MonoBehaviour
{
    public CooldownComponent cooldownDialogue;

    public List<string> dialogues;
    public float offsetForDialog = 1.5f;

    void Start()
    {
        cooldownDialogue = new CooldownComponent(2f, 1f);
    }

    private void Update()
    {
        if(cooldownDialogue.Use())
        {
            Game.current.floatingDialog.Create(dialogues.Rand(), transform.position + Vector3.up * offsetForDialog, transform);
        }
    }
}
