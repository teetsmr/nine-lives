using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;

    private const string MUSIC_PREF = "musicMuted";
    private bool musicMuted;

    private void Awake()
    {
        if (Instance && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        musicMuted = PlayerPrefs.GetInt(MUSIC_PREF, 0) == 1;
        ApplyMusicMute(musicMuted);
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ToggleMusicMute()
    {
        SetMusicMute(!musicMuted);
    }

    public void SetMusicMute(bool value)
    {
        musicMuted = value;
        ApplyMusicMute(musicMuted);
        PlayerPrefs.SetInt(MUSIC_PREF, musicMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void ApplyMusicMute(bool m)
    {
        if (musicSource) musicSource.mute = m;
        // DO NOT touch sfxSource here
    }

    public bool IsMusicMuted => musicMuted;
}
