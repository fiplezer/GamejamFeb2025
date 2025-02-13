using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider voiceSlider;
    public AudioMixer audioMixer;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume", 1f);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        voiceSlider.onValueChanged.AddListener(SetVoiceVolume);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20);
    }

    public void SetVoiceVolume(float volume)
    {
        PlayerPrefs.SetFloat("VoiceVolume", volume);
        audioMixer.SetFloat("VoiceVolume", Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20);
    }
}
