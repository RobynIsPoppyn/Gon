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
        musicSource.Stop();
        musicSource.clip = newBgm;
        StartCoroutine(PlayAfterDelay(17.5f));
    }

    private IEnumerator PlayAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        musicSource.Play();
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
}