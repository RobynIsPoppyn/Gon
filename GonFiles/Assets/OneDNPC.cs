using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneDNPC : NPCDialogueTrigger
{
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            dialogueUI.CrossFadeAlpha(1f, 1f, false);
        }
    }

    
}
