using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("level timer in seconds")]
    [SerializeField] float levelTime;
    bool timeIsFinished = false;
     void Start()
    {
        levelTime +=3*levelTime * PlayerPrefsControl.GettDiffculty(); 
    }
    void Update()
    {
        if(timeIsFinished){return;}
        GetComponent<Slider>().value = Time.timeSinceLevelLoad /levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime );

        if(timerFinished)
        {
           FindObjectOfType<LevelController>().LevelFinished();
           timeIsFinished = true;
        }
        
    }
}
