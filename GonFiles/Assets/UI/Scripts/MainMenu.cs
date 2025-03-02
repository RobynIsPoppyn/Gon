using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Individual Elements to Hide
    [SerializeField] private CanvasGroup menuCanvas;
    [SerializeField] private GameObject logo;
    [SerializeField] private Image bg;
    [SerializeField] private GameObject startBtn;
    [SerializeField] private Button settingsBtn;
    [SerializeField] private Button creditsBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] public GameObject player;

    private int transitionDuration = 2;
    private bool isFaded = false;
    private float fadeTimer = 0f;
    public static MainMenu instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        fadeTimer += Time.deltaTime;

        if (!isFaded && fadeTimer >= 0.2f)
        {
            menuCanvas.alpha = Mathf.Lerp(1f, 0f, (fadeTimer - 0.2f) / 2f);

            if (fadeTimer >= 2.2f)
            {
                menuCanvas.alpha = 0f;
                isFaded = true;
            }
        }
    }

    // Play Logic
    public void StartGame()
    {
        startBtn.SetActive(false);
        HideMenu();

        Invoke(nameof(DestroySelf), transitionDuration);
    }

    // Quit Logic
    public void Quit()
    {
        Application.Quit();
    }

    private void HideMenu()
    {
        // Vignette
        bg.CrossFadeAlpha(0, 3, false);

        // Settings Btn
        settingsBtn.enabled = false;
        TextMeshProUGUI settingsTxt = settingsBtn.GetComponentInChildren<TextMeshProUGUI>();
        settingsTxt.CrossFadeAlpha(0, 1, false);

        // Credits Btn
        creditsBtn.enabled = false;
        TextMeshProUGUI creditTxt = creditsBtn.GetComponentInChildren<TextMeshProUGUI>();
        creditTxt.CrossFadeAlpha(0, 1.5f, false);

        // Quit Btn
        quitBtn.enabled = false;
        TextMeshProUGUI quitTxt = quitBtn.GetComponentInChildren<TextMeshProUGUI>();
        quitTxt.CrossFadeAlpha(0, 1.75f, false);
    }

    // Destroy after starting game
    private void DestroySelf()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        Destroy(gameObject);
    }
}
