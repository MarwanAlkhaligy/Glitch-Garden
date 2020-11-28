using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathvfx;
    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathvfx){ return;}
        GameObject deathvfxObject = Instantiate(deathvfx, transform.position, transform.rotation);
        Destroy(deathvfxObject , 1f);
    }
}
