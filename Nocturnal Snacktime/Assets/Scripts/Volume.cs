using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider sliderVolume;
    public float prevVolume;

    // Start is called before the first frame update
    void Start()
    {
        sliderVolume.value = AudioListener.volume;
        prevVolume = sliderVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        float sliderValue = sliderVolume.value;

        Debug.Log("sliderValue: " + sliderValue);

        if (prevVolume != sliderValue)
        {
            Debug.Log("in the IF!!! sliderValue: " + sliderValue);
            ChangeVolume(sliderValue);

            prevVolume = sliderValue;
        }
    }

    public void ChangeVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
