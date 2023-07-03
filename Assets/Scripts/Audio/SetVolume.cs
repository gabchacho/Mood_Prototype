using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mix;
    private Slider _slider;

    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        mix.SetFloat("MusicVol", Mathf.Log10(_slider.value) * 20f);
    }

    public void SetLevel(float sliderVal)
    {
        //take 0.0001 - 1 slider value and turn it into a value on a logarithmic scale-- better vol scaling
        mix.SetFloat("MusicVol", Mathf.Log10(sliderVal) * 20f);
    }

}
