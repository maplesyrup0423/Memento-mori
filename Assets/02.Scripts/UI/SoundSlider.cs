using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField]
    private Slider bgmSlider;

    private float sfxVol = 0.5f;
    private float bgmVol = 0.5f;

    private void Start() {
        if (PlayerPrefs.HasKey("SfxVolume")) {
            sfxVol = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
        } else {
            sfxVol = 0.5f;
        }

        sfxSlider.value = sfxVol;

        if (PlayerPrefs.HasKey("BgmVolume")) {
            bgmVol = PlayerPrefs.GetFloat("BgmVolume", 0.5f);
        } else {
            bgmVol = 0.5f;
        }

        bgmSlider.value = bgmVol;
    }

    private void Update() {
        sfxVol = sfxSlider.value;
        PlayerPrefs.SetFloat("SfxVolume", sfxVol);
        bgmVol = bgmSlider.value;
        PlayerPrefs.SetFloat("BgmVolume", bgmVol);
    }
}
