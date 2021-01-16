using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
  public enum SCENES { SELF = 0, TITLE, GAME }

  public SCENES defaultScene;

  private void Start() {
    SwitchScene(defaultScene);
  }

  public void SwitchScene(SCENES scene)
  {
    bool sceneLoaded = false;
    for (int i = 0; i < SceneManager.sceneCount; i++)
    {
      if(SceneManager.GetSceneAt(i) == SceneManager.GetActiveScene())
        continue;
      else if(SceneManager.GetSceneAt(i) == SceneManager.GetSceneByBuildIndex((int)scene))
        sceneLoaded = true;
      else{
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i).buildIndex);
      }
    }

    if(sceneLoaded)
      return;

    SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);
  }
}
