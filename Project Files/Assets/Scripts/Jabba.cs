﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jabba : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
       GameObject game = other.gameObject;

       if(game.GetComponent<Defender>())
       {
         GetComponent<Attacker>().Attack(game);
       }
   }
}
