using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandleNotification : MonoBehaviour {
    public Slider slider;
    public AudioClip clip;
    public AudioSource aSource;

    void Update()
    {
        
    }

    public void setIntensity(float intensity)
    {
        slider.value = intensity;
    }

    public void playSound()
    {
        aSource.Stop();
        aSource.clip = clip;
        aSource.Play();
    }
	
}
