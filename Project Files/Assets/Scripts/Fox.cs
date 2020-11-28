using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject game = other.gameObject;

        if(game.GetComponent<GraveStone>())
        {
                 GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if(game.GetComponent<Defender>())
        {
            
           GetComponent<Attacker>().Attack(game);
        }
    }
}
