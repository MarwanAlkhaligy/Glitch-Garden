using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
     
    Text livesText;
    float lives ;
    

    void Start()
    {
        lives = baseLives - PlayerPrefsControl.GettDiffculty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
        
    }
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
           lives -= damage;
           if(lives < 0) lives = 0;
            UpdateDisplay();
             if(lives  <= 0)
            {
                FindObjectOfType<LevelController>().HandleLoseCondition();
               
            }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
