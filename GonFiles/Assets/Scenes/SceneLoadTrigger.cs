using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private string[] scenesToLoad;
    [SerializeField] private string sceneName;
    [SerializeField] private AudioClip newBg;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            if (scenesToLoad.Length > 0) LoadScenes();
            if (sceneName != "") LoadNewScene();
        }
    }

    private void LoadScenes()
    {
        bool isSceneLoaded = false;
        for (int i = 0; i < scenesToLoad.Length; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == scenesToLoad[i])
                {
                    isSceneLoaded = true;
                    break;
                }
            }

            if (!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            }
        }
    }

    private void LoadNewScene()
    {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        if (PlayerManager.instance != null)
        {
            Destroy(PlayerManager.instance.gameObject);
        }

        yield return null; // Wait one frame to ensure it's removed

        SceneManager.LoadScene(sceneName);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.ChangeBGM(newBg);
        }
    }
}
