using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
   
    AudioSource audio;
    
    void Awake()
    {
        if(FindObjectsOfType<MusicPlayer>().Length > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsControl.GetMasterVolume();
    }
    
    void Update()
    {
       
    }

    public void SetVolume(float volume)
    {
        audio.volume = volume;
    }

    
}
