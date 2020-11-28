using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float damage = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *Time.deltaTime *moveSpeed );
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if(health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);

        }
       
    }
}
