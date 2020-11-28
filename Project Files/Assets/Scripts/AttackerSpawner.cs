using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;


    bool spawn = true;

    

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawmAttacker();
        }
    }
    public void StopSpawn()
    {
        spawn = false;
    }

    private void SpawmAttacker()
    {
        var attackerIndex = Random.Range(0,attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    } 

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
       
        newAttacker.transform.parent = transform;
        
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
