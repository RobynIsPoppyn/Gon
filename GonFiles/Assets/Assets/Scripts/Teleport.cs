using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float firstDuration = 40f;
    [SerializeField] private float secondDuration = 20f;
    [SerializeField] private GameObject telePt;
    [SerializeField] private GameObject camContainer;
    [SerializeField] private GameObject failCanvas;
    [SerializeField] private AudioClip balding;

    private void Start()
    {
        StartCoroutine(FailTimer());
    }

    private IEnumerator FailTimer()
    {
        yield return new WaitForSeconds(firstDuration);

        AudioManager.instance.ChangeBGM(balding);
        PlayerManager player = PlayerManager.instance;
        Component[] components = camContainer.GetComponents<Component>();
        Component script = components.FirstOrDefault(c => c.GetType().Name == "FollowPlayer");
        MonoBehaviour monoScript = script as MonoBehaviour;

        yield return new WaitForSeconds(secondDuration);

        AudioManager.instance.playSFX(AudioManager.instance.failSound);
        AudioManager.instance.StopMusic();
        failCanvas.SetActive(true);

        player.transform.position = telePt.transform.position;
        monoScript.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform player = other.transform.parent;

            if (player != null)
            {
                player.position = telePt.transform.position;
            }
        }
    }
}
