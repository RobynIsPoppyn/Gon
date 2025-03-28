using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTimer = 1f;
    public bool isNew = false;

    public void Start()
    {
        if (isNew)
        {
            transition.SetTrigger("End");
        }
    }

    public void LoadNextLevel(int index, AudioClip newBg)
    {
        StartCoroutine(LoadLevel(index, newBg));
    }

    IEnumerator LoadLevel(int levelIndex, AudioClip newBg)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTimer);

        if (PlayerManager.instance != null)
        {
            Destroy(PlayerManager.instance.gameObject);
        }

        yield return null;

        AudioManager.instance.playSFX(AudioManager.instance.finishSound);
        SceneManager.LoadScene(levelIndex);

        if (AudioManager.instance != null && newBg != null)
        {
            AudioManager.instance.ChangeBGM(newBg);
        }
    }
}
