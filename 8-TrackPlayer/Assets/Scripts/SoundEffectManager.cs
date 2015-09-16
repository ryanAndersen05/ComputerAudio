using UnityEngine;
using System.Collections;

public class SoundEffectManager : MonoBehaviour {
    public AudioClip[] soundEffects;



    AudioSource aSource;

    public const int RESET = 0;
    public const int PLAY = 1;
    public const int PAUSE = 2;

    void Awake()
    {
        aSource = GetComponent<AudioSource>();

    }

    public void playSound(int soundLocation)
    {
        aSource.Stop();
        aSource.clip = soundEffects[soundLocation];
        aSource.Play();
    }
}
