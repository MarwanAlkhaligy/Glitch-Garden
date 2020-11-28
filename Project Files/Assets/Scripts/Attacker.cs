using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
     GameObject currentTarget;
     float currentSpeed= 1f;

     private void Awake() {
         if(FindObjectOfType<LevelController>())
         {
             FindObjectOfType<LevelController>().AttackerSpawned();
         }
         
     }

   
    private void OnDestroy()
    {
        if(FindObjectOfType<LevelController>()){
            FindObjectOfType<LevelController>().AttackerKilled();
        }
         
    }

    public void SetMoveSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false );
        }
    }
    public  void Attack(GameObject target)
    {
        if(GetComponent<Animator>()){
             GetComponent<Animator>().SetBool("IsAttacking", true);
             currentTarget = target;
        }
       
    }

    private void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
