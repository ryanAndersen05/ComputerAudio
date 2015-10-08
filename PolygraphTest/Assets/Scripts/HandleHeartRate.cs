using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandleHeartRate : MonoBehaviour {
    public Text heartRateText;
    public Slider heartRateSlider;
    public Slider heartRateVolume;
    public float currentHeartRate = 60;

    private AudioSource aSource;

    void Update()
    {
        heartRateText.text = "" + (int)currentHeartRate;
    }

    public void setVolume(float volume)
    {
        aSource.volume = volume;
    }

    public void setHeartRate(float heartRate)
    {
        this.currentHeartRate = heartRate;
    }

    public void setVolumeSlider(float value)
    {
        this.heartRateVolume.value = value;
    }

    public void setRateSlider(float value)
    {
        this.heartRateSlider.value = value;
    }

    void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }
}
