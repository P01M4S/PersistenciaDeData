using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer _audioMix;
    public Slider _slider;
    public string _volumenParameter;
    public Toggle _mute;
    public bool muted;

    void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(ChangeVolume);
        _mute = GetComponentInChildren<Toggle>();
        _mute.onValueChanged.AddListener(Mute);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float volume = PlayerPrefs.GetFloat(_volumenParameter, 1);
        _audioMix.SetFloat(_volumenParameter, Mathf.Log10(volume) * 20);
        _slider.value = volume;
        string muteValue = PlayerPrefs.GetString(_volumenParameter + "Mute", "False");
        if (muteValue == "False")
        {
            muted = false;
        }
        else if (muteValue == "True")
        {
            muted = true;
        }
        _mute.isOn = !muted;
    }

    void ChangeVolume(float value)
    {
        _audioMix.SetFloat(_volumenParameter, Mathf.Log10(value) * 20);
        _mute.isOn = true;
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumenParameter, _slider.value);
        PlayerPrefs.SetString(_volumenParameter + "Mute", muted.ToString());
    }

    void Mute(bool soundEnabled)
    {
        if (soundEnabled)
        {
            float lastVolume = PlayerPrefs.GetFloat(_volumenParameter, 1f);
            _audioMix.SetFloat(_volumenParameter, Mathf.Log10(lastVolume) * 20);
            muted = false;
        }
        else
        {
            PlayerPrefs.SetFloat(_volumenParameter, _slider.value);
            _audioMix.SetFloat(_volumenParameter, Mathf.Log10(_slider.minValue) * 20);
            muted = true;
        }
    }

}
