using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderScript : MonoBehaviour
{
   [SerializeField] Defender defenderPrefab;  
   private void Start() {
       LabelButtinWithCost();
   }

   private void LabelButtinWithCost()
   {
       Text costText = GetComponentInChildren<Text>();
       if(!costText){
           //Debug.LogError(name + "has no cost text");
       }else{
           costText.text = defenderPrefab.GetStarCost().ToString();
       }

   }
   void OnMouseDown()
   {
       var buttons = FindObjectsOfType<DefenderScript>();
       foreach (DefenderScript button in buttons)
       {
           button.GetComponent<SpriteRenderer>().color = new Color32(41 , 41 , 41 , 255);
       }
       GetComponent<SpriteRenderer>().color = Color.white;
       FindObjectOfType<DefenderSpawner>().SetDefender(defenderPrefab);
   }

   
   void OnCollisionEnter2D(Collision2D other)
   {
       
   }
}
