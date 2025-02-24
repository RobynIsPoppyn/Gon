using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(false);
        }
    }
}
