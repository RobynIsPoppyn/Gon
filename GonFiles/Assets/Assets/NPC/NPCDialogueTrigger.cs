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

    private bool m_initiated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!m_initiated)
                AudioManager.instance.playSFX(AudioManager.instance.npcSound);
            dialogueUI.CrossFadeAlpha(1f, 1f, false);
            m_initiated = true;
        }
    }
}
