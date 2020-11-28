using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   [SerializeField] float timeOfDelay = 4f;
   
   int currenSceneIndex;

   private void Start() {
      currenSceneIndex = SceneManager.GetActiveScene().buildIndex;

      if(currenSceneIndex == 0)
      {
          StartCoroutine(WaitForSecond());
      }

   }
   IEnumerator WaitForSecond()
   {
       yield return new WaitForSeconds(timeOfDelay);
       LoadNextScene();
   }
   public void RestartScene()
   {
      Time.timeScale = 1;
     SceneManager.LoadScene(currenSceneIndex);
   }

    public void MainMenuScene()
   {
     Time.timeScale = 1;
     SceneManager.LoadScene("Start Screen");
   }
    public void LoadNextScene()
   {
     if(currenSceneIndex + 1 == 9){
        if(FindObjectOfType<MusicPlayer>()){
           Destroy(FindObjectOfType<MusicPlayer>().gameObject);
        }
     }
     SceneManager.LoadScene(currenSceneIndex + 1);
   }
   public void LoadGame()
   {
     SceneManager.LoadScene("Splash Screen");
   }

   public void OptionScene()
   {
     SceneManager.LoadScene("Option Scene");
   }

   public void LoadYouLose()
   {
     SceneManager.LoadScene("LoseScene");
   }

   public void QuitGame()
   {
       Application.Quit();
   }

}
