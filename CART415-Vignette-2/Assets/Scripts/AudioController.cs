using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _ambientSound = null;
    [SerializeField] private AudioSource _sfxSound = null;
    [SerializeField] private float _lowPitchRange = 0.95f;
    [SerializeField] private float _highPitchRange = 1.05f;

    public static AudioController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySingle(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("Clip is null");
        }

        _sfxSound.PlayOneShot(clip);
    }

    public void PlayRandomSfx(float lowPitchRange, float highPitchRange, params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        _sfxSound.pitch = randomPitch;
        _sfxSound.PlayOneShot(clips[randomIndex]);
    }
    public void PlayRandomSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(_lowPitchRange, _highPitchRange);

        _sfxSound.pitch = randomPitch;
        _sfxSound.PlayOneShot(clips[randomIndex]);
    }


    public void SetAmbientSound(AudioClip clip)
    {
        _ambientSound.clip = clip;
        _ambientSound.Play();
    }
}