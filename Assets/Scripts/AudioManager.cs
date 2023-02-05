using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource loopAudio;
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip[] sfx;
    [SerializeField] AudioClip music;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance) Destroy(instance);

        instance = this;
        DontDestroyOnLoad(this);

        PlayMusic();

    }

    public void PlayMusic()
    {
        loopAudio.clip = music;
        loopAudio.Play();
    }

    public void PlayHeartSound() => audioSource.PlayOneShot(sfx[0]);
    public void PlayTryAgain() => audioSource.PlayOneShot(sfx[1]);
    public void PlayWin() => audioSource.PlayOneShot(sfx[2]);
    public void PlayRootMove() => audioSource.PlayOneShot(sfx[3]);

}
