using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioMixer gonMixer;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource uiSource;

    [Header("---------- Audio Clips ----------")]
    public AudioClip bgm;
    public AudioClip uiHover;
    public AudioClip uiSelect;
    // Add other sounds here as needed

    public static AudioManager instance;

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

    // Play BGM on start
    private void Start()
    {
        LoadVolume("masterVolume", "Master");
        LoadVolume("musicVolume", "Music");
        LoadVolume("sfxVolume", "Sfx");
        LoadVolume("uiVolume", "Ui");

        musicSource.clip = bgm;
        musicSource.Play();
    }

    // Change BGM
    public void ChangeBGM(AudioClip newBgm)
    {
        StartCoroutine(FadeSwitch(newBgm));
    }

    private System.Collections.IEnumerator FadeSwitch(AudioClip newBgm)
    {
        float startVolume = musicSource.volume;

        for (float i = 0; i < 2f; i += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, i / 2f);
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = newBgm;
        musicSource.Play();

        for (float i = 0; i < 2; i+= Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0, startVolume, i / 2f);
            yield return null;
        }
    }

    private void LoadVolume(string playerKey, string mixerParam)
    {
        if (PlayerPrefs.HasKey(playerKey))
        {
            float volume = PlayerPrefs.GetFloat(playerKey);
            gonMixer.SetFloat(mixerParam, Mathf.Log10(volume) * 20);
        }
    }

    // Play a sound effect once
    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void playUI(AudioClip clip)
    {
        uiSource.PlayOneShot(clip);
    }
}