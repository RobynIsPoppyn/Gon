using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsUI;

    public static PauseMenu instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && settingsUI.activeSelf)
        {
            settingsUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && MainMenu.instance == null && settingsUI.activeSelf == false)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0001f;
        isPaused = true;
    }

    public void Quit()
    {
        /*
        Destroy(GameObject.Find("AudioManager"));
        SceneManager.LoadScene(0); // Loads the first scene and resets it back to the main menu state
        Resume();
        */

        Application.Quit();
    }
}
