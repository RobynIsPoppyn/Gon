using UnityEngine;

public class NPCDialogueTrigger2D : MonoBehaviour
{
    public GameObject dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueUI.SetActive(false);
        }
    }
}
