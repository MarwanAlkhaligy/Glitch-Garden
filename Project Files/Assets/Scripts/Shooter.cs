using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
   [SerializeField] GameObject projectile, gun;
   GameObject projectileParent;

   AttackerSpawner myLaneSpawner;
   Animator animator;
   const string PROJECTILE_PARENT_NAME = "Projectile";

   private void Start()
   {
      SetLaneSpawner();
      animator = GetComponent<Animator>();
      CreateProjectileParent();
   }
   private void CreateProjectileParent()
   {
       projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent) 
        {
           projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
   }
    
    private void Update()
    {
       if (!myLaneSpawner) return;
       if(IsAttackerInLane())
       {
          animator.SetBool("IsAttacking", true);
       }
     else
       {
          animator.SetBool("IsAttacking", false);
       }

   } 

   private bool IsAttackerInLane()
   {
      return !(myLaneSpawner.transform.childCount <= 0);      
   }

   public void Fire()
   {
      GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
      newProjectile.transform.parent = projectileParent.transform;
   }

   private void SetLaneSpawner()
   {
      AttackerSpawner[] spawner = FindObjectsOfType<AttackerSpawner>();

      foreach (AttackerSpawner attacker in spawner)
      {
         bool IsCloseEnough = (Mathf.Abs(attacker.transform.position.y - transform.position.y) <= Mathf.Epsilon);
         if(IsCloseEnough)
         {
           myLaneSpawner = attacker;
         }
      }
   }
}
