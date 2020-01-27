using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    //This is a temporary script to test loading mechanics.  This will be added to where level loading and scene management is handled 
    //within the game architecture. 
    // Start is called before the first frame update

    public GameObject loadingScreen;
    public Slider loadingSlider;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            loadingSlider.value = progress;

            yield return null;
        }
    }

}
