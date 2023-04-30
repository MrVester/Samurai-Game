using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    private AudioSource audioSrc;

    public Toggle toggleVolume;
    public Slider slider;
    public TextMeshProUGUI soundValue;

    void Start()
    {
        toggleVolume.onValueChanged.AddListener((value) => SetVolumeZero());
        slider.onValueChanged.AddListener((value) => SetVolume());
        audioSrc = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("SaveVolume"))
        {
            slider.value = audioSrc.volume = PlayerPrefs.GetFloat("SaveVolume");
        }

        else
        {
            slider.value = audioSrc.volume = 0.2f;
        }

    }





    void Update()
    {

        soundValue.text = Mathf.Round(f: slider.value * 100) + "%";
    }

    public void SetVolume()
    {
        audioSrc.volume = slider.value;
        PlayerPrefs.SetFloat("SaveVolume", slider.value);
        if (slider.value > 0 && !toggleVolume.isOn)
        {
            //PlayerPrefs.SetFloat("VolumeBuf", 0f);
            toggleVolume.isOn = true;

        }

        if (slider.value == 0 && toggleVolume.isOn)
        {
            toggleVolume.isOn = false;
        }
    }
    public void SetVolumeZero()
    {
        if (slider.value > 0 && !toggleVolume.isOn)
        {
            PlayerPrefs.SetFloat("VolumeBuf", slider.value);
            PlayerPrefs.SetFloat("SaveVolume", 0f);
            audioSrc.volume = slider.value = 0f;
        }

        if (slider.value == 0 && toggleVolume.isOn)
        {
            audioSrc.volume = slider.value = PlayerPrefs.GetFloat("VolumeBuf");

        }
    }





    /*[Header("Components")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    [Header("Parameters")]
    [SerializeField] public float volume;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if(sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.volume = this.volume;
            }
        }
        else
        {
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }

private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
        if(sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<slider>();
            this.volume = slider.value;

            if(this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume); 
            }

            GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
            if(textObj != null)
            {
                this.text = textObj.GetComponent<Text>();

                this.text.text = Mathf.Round(f: this.volume * 100) + "%";
            }
        }

        this.audio.volume = this.volume;
    }*/
}
