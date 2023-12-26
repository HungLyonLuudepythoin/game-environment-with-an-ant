using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioClip death, bgMusic;
    [SerializeField]
    private AudioSource soundFX, bgMusicSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    public void PlayDeath()
    {
        soundFX.PlayOneShot(death);
    }
    public void PlayMusic()
    {
        bgMusicSource.Play();
    }
}
