using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLab;
    [SerializeField] GameObject loseLab;
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] int numberOfAttacker = 0;
    bool levelTimerFinish = false;


    private void Start() {
        winLab.SetActive(false);
        loseLab.SetActive(false);
    }

    public void HandleLoseCondition()
    {
        loseLab.SetActive(true);
        Time.timeScale = 0;
    }
    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    public void AttackerKilled()
    {
        numberOfAttacker--;
        if(numberOfAttacker <= 0 && levelTimerFinish )
        {
             StartCoroutine(HandleWin());
        }
       
       
    }
    IEnumerator HandleWin()
    {
        winLab.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelFinished()
    {
        levelTimerFinish = true;
        StopSpawner();
    }

    private void StopSpawner()
    {
        AttackerSpawner[] attackSpawner = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackSpawner)
        {
          spawner.StopSpawn();
        }
    }
}
