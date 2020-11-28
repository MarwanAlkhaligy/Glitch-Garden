﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsControl : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master  volume" ;
    const string DIFFICULTY_KEY = "difficulty" ;

    const float MAX_VOLUME = 1f;
    const float MIN_VOLUME = 0f;
     
    const float MAX_DIFFICULTY = 2f;
    const float MIN_DIFFICULTY= 0f;
     

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME )
        {
             PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            
        }
        else{
            Debug.LogError("Master volume is out of range");
        }
       
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDiffculty(float difficulty)
    {
        if(difficulty>= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY,difficulty);
        }
        else{
            Debug.LogError("out of Range");
        }
        
    }
     public static float GettDiffculty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }


}
