using UnityEngine;
using System.Collections;

public class SoundEffectManager : MonoBehaviour {
    public AudioClip[] soundEffects;



    AudioSource aSource;

    public const int RESET = 0;
    public const int PLAY = 1;
    public const int PAUSE = 2;
	public const int CHANNEL_UP = 3;
	public const int CHANNEL_DOWN = 4;
	public const int STOP = 5;
	public const int FAST_FORWARD = 6;
	public const int VOLUME = 7;

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
