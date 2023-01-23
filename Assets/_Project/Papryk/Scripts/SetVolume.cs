using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _totalSlider, _musicSlider, _sfxSlider;

    private void Awake()
    {
        _totalSlider.value = PlayerPrefs.GetFloat("TotalVolume", 0.5f);
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    private void Start()
    {
        _mixer.SetFloat("TotalVolume", Mathf.Log10(_totalSlider.value) * 20);
        _mixer.SetFloat("MusicVolume", Mathf.Log10(_musicSlider.value) * 20);
        _mixer.SetFloat("SFXVolume", Mathf.Log10(_sfxSlider.value) * 20);
    }
    public void SetSounds()
    {
        float sliderValue = _totalSlider.value;
        
        
        if (sliderValue == 0)
        {
            PlayerPrefs.SetFloat("TotalVolume", -80);
            _mixer.SetFloat("TotalVolume", -80);
        }
        else
        {
            PlayerPrefs.SetFloat("TotalVolume", sliderValue);
            _mixer.SetFloat("TotalVolume", Mathf.Log10(sliderValue) * 20);
        }
    }

    public void SetMusic()
    {
        float sliderValue = _musicSlider.value;
        
        
        if (sliderValue == 0)
        {
            PlayerPrefs.SetFloat("MusicVolume", -80);
            _mixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", sliderValue);
            _mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        }
    }

    public void SetSFX()
    {
        float sliderValue = _sfxSlider.value;
        
        
        if (sliderValue == 0)
        {
            PlayerPrefs.SetFloat("SFXVolume", -80);
            _mixer.SetFloat("SFXVolume", -80);
        }
        else
        {
            PlayerPrefs.SetFloat("SFXVolume", sliderValue);
            _mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        }
    }
}