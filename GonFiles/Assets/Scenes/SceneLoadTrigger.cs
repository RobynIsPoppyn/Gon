using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private string[] scenesToLoad;
    [SerializeField] private string[] scenesToUnload;
    [SerializeField] private string sceneName;
    [SerializeField] private AudioClip newBg;

    private static AudioManager manager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            if (scenesToLoad.Length > 0) LoadScenes();
            if (scenesToUnload.Length > 0) UnloadScenes();
            if (sceneName != null) LoadNewScene();
            if (manager != null) manager.ChangeBGM(newBg);
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

    private void UnloadScenes()
    {
        for (int i = 0; i < scenesToUnload.Length; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == scenesToUnload[i])
                {
                    SceneManager.UnloadSceneAsync(scenesToUnload[i]);
                }
            }
        }
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
