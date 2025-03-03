using UnityEngine;
using TMPro;

public class NPCDialogueTrigger : MonoBehaviour
{
    public TextMeshProUGUI dialogueUI;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        dialogueUI.CrossFadeAlpha(0f, 0f, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.playSFX(AudioManager.instance.npcSound);
            dialogueUI.CrossFadeAlpha(1f, 1f, false);
        }
    }
}
