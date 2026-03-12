using UnityEditor;
using UnityEngine;


public enum SoundType
{ 
    Buy,
    UnBuy,
    ChoseSkin,
    Jump
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    [SerializeField] private AudioClip backgroundMusic; // 🎵 Nhạc nền
    public static SoundManager instance;

    private AudioSource audioSource;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic();
        DontDestroyOnLoad(gameObject);
    }

    public static void PlayrSound(SoundType sound ,float volume=1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic == null)
        {
            Debug.LogWarning("⚠ Chưa gán backgroundMusic!");
            return;
        }

        audioSource.loop = true;
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

}
