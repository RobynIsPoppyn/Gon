using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    // Individual Elements to Hide
    [SerializeField] private CanvasGroup menuCanvas;
    [SerializeField] private Image logo;
    [SerializeField] private Image bg;
    [SerializeField] private UnityEngine.UI.Button startBtn;
    [SerializeField] private UnityEngine.UI.Button settingsBtn;
    [SerializeField] private UnityEngine.UI.Button creditsBtn;
    [SerializeField] private UnityEngine.UI.Button quitBtn;
    [SerializeField] private TextMeshProUGUI moveTip;
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] public GameObject player;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ParticleSystem logoParticles;
    [SerializeField] private Camera playerCam;

    private int transitionDuration = 2;
    private bool isFaded = false;
    private float fadeTimer = 0f;
    public static MainMenu instance;


    private void Awake()
    {
        instance = this;
        moveTip.CrossFadeAlpha(0, 0, false);
    }

    private void Start()
    {
        PlayLogoParticlesAtButtonPosition();
        StartCoroutine(delayPlayer());

        // Set Graphics Quality
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("graphicsQuality", 3));

        // Set Fullscreen
        bool isFullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        Screen.fullScreen = isFullscreen;

        // Set Saved Resolution
        int savedRes = PlayerPrefs.GetInt("resolutionIndex", Screen.resolutions.Length - 1);
        Resolution res = Screen.resolutions[savedRes];
        Screen.SetResolution(res.width, res.height, isFullscreen);
    }

    public IEnumerator delayPlayer(){
        yield return null;
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
        PlayExplosionAtButtonPosition();
        startBtn.gameObject.SetActive(false);
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
        bg.CrossFadeAlpha(0, 2, false);

        // Logo
        logo.CrossFadeAlpha(0, 1.5f, false);

        // Subtitle
        subtitle.CrossFadeAlpha(0, 1f, false);

        // moveTip
        moveTip.CrossFadeAlpha(1, 2, false);

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

    private void PlayExplosionAtButtonPosition()
    {
        RectTransform buttonRect = startBtn.GetComponent<RectTransform>();
        Vector2 buttonScreenPos = RectTransformUtility.WorldToScreenPoint(null, buttonRect.position);
        Vector3 buttonWorldPos = playerCam.ScreenToWorldPoint(new Vector3(buttonScreenPos.x, buttonScreenPos.y, 10f));

        explosion.transform.position = buttonWorldPos;
        explosion.Play();
    }

    private void PlayLogoParticlesAtButtonPosition()
    {
        RectTransform logoRect = logo.GetComponent<RectTransform>();
        Vector2 logoScreenPos = RectTransformUtility.WorldToScreenPoint(null, logoRect.position);
        Vector3 logoWorldPos = playerCam.ScreenToWorldPoint(new Vector3(logoScreenPos.x, logoScreenPos.y, 10f));

        logoParticles.transform.position = logoWorldPos;
    }
}
