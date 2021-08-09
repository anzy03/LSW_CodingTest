using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip _audioClip)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}