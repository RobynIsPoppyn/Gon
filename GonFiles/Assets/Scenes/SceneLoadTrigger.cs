using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private string[] scenesToLoad;
    [SerializeField] private bool loadNext = false;
    [SerializeField] private AudioClip newBg;
    [SerializeField] private TransitionLoader loader;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            if (scenesToLoad.Length > 0) LoadScenes();
            if (loadNext) loader.LoadNextLevel(newBg);
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
}
