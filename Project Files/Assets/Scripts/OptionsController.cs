using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultdifficulty = 0f;
    void Start()
    {
        volumeSlider.value = PlayerPrefsControl.GetMasterVolume() ;
        difficultySlider.value = PlayerPrefsControl.GettDiffculty() ;
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer) 
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("no music Player");
        }

    }

    public void SaveAndExit()
    {
        PlayerPrefsControl.SetMasterVolume(volumeSlider.value);
        PlayerPrefsControl.SetDiffculty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().MainMenuScene();
    }
    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultdifficulty;
    }
}
