using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
   public void ExitGame() {
    Application.Quit();
   }

   public void ReplayLevel() {
    SceneManager.LoadSceneAsync(SceneIDS.levelSceneID);
   }
   public void ReturnToMap(){
      SceneManager.LoadSceneAsync(SceneIDS.levelSceneID);
   }


}
