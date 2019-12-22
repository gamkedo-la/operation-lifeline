using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{  

    public void LoadScene(string sceneToLoad)
    {
        GameManager.Instance.LoadScene(sceneToLoad);
    }

    public void ReloadCurrentScene()
    {
        GameManager.Instance.LoadScene(SceneManager.GetActiveScene().ToString());
    }
}
