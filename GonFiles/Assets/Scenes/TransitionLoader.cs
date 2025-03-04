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

    public void LoadNextLevel(AudioClip newBg)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, newBg));
    }

    IEnumerator LoadLevel(int levelIndex, AudioClip newBg)
    {
        if (PlayerManager.instance != null)
        {
            Destroy(PlayerManager.instance.gameObject);
        }

        yield return null;
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTimer);

        SceneManager.LoadScene(levelIndex);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.ChangeBGM(newBg);
        }
    }
}
