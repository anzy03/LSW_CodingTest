using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Used to call PLayOneShot on AudioSource.
    /// </summary>
    /// <param name="_audioClip">Audio Clip to play</param>
    public void PlayOneShot(AudioClip _audioClip)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}