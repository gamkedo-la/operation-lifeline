﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private bool isPaused = false;
    public bool IsPaused {
        get {
            return isPaused;
        }
    }

	[SerializeField] private GameObject pauseMenu = null;

    private GameObject homeBase;
    private GameObject player;
    private float totalJourneyDistanceThisLevel = 0;
    [SerializeField] private float progressIndicatorUpdateInterval = 3;
    private Scrollbar progressIndicatorUI;
	
    //From Loading Screen Test
	[SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;

    private FMOD.Studio.EventInstance instance;

    public void SetPause(bool toPause = true) {
        isPaused = toPause;
		pauseMenu.SetActive(toPause);
    }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            if ( this != _instance)
            Destroy(gameObject);
        }  
    }

    public void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single) {

        if (sceneName.Equals(SceneManager.GetActiveScene().name))
        {
            SceneManager.LoadScene(sceneName, mode);
            InitializeScene();
            Debug.Log("Reloading current Scene");
        }
        else
        {
            StartCoroutine(MoveToScene(sceneName, LoadSceneMode.Single));
        }

    }

	private void Start() {
		var scrollbarsInChildren = GetComponentsInChildren<Scrollbar>();
		if (scrollbarsInChildren.Length > 0) {
			progressIndicatorUI = GetComponentsInChildren<Scrollbar>()[0];
		}
        InitializeScene();     
    }

    private void InitializeScene() {
        if (loadingScreen) { loadingScreen.SetActive(true); }

        if (RuntimeManager.HasBankLoaded("Master"))//Check that FMOD Master Bank has loaded before Initializing Scene
        {
            if (loadingScreen) { loadingScreen.SetActive(false); }
            homeBase = GameObject.FindWithTag("HomeBase");
            player = GameObject.FindWithTag("Player");
            totalJourneyDistanceThisLevel = GetTotalJourneyDistance();
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(false);
            }

            if (homeBase && player)
            {
                StopCoroutine(playerPositionUpdate());
                StartCoroutine(playerPositionUpdate());
            }
        }
        else
        {
            InitializeScene(); //If FMOD isn't loaded Initialize again. 
        }

    }

    private IEnumerator MoveToScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
				
		if (loadingScreen != null)
		{
			loadingScreen.SetActive(true);
		}

		//loadingScreen.SetActive(true);

		if (RuntimeManager.HasBankLoaded("Master"))
        {			
			//Scene oldScene = SceneManager.GetActiveScene();
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
			
			while (!operation.isDone)
            {
				float progress = Mathf.Clamp01(operation.progress);	
                Debug.Log(progress + " :  Actual progress: " + operation.progress * 100 + "%");
                if (loadingScreen)
                {
                    loadingSlider.value = progress;
                }
                yield return null;
            }			
			//SceneManager.UnloadSceneAsync(oldScene);
			InitializeScene();
        }
        else
        {
			yield return new WaitForSeconds(0.5f);
			StartCoroutine(MoveToScene(sceneName, LoadSceneMode.Single));
		}
    }
    
    private IEnumerator playerPositionUpdate() {
        while (true) {
			if (!player) { break; }
            Vector3 playerCurrentPosition = player.transform.position;
			if (progressIndicatorUI)
			{
				progressIndicatorUI.value = playerCurrentPosition.y / totalJourneyDistanceThisLevel;
			}
            yield return new WaitForSeconds(progressIndicatorUpdateInterval);
        }
    }

    private float GetTotalJourneyDistance() {
        float distance = 0;

        if (homeBase && player) {
            distance = (homeBase.transform.position - player.transform.position).magnitude; 
        }

        return distance;
    }

	public void uiSoundOnHover() 
	{
		FMODUnity.RuntimeManager.PlayOneShot("event:/Main/UI/Menu Navigation");
	}

	public void uiSoundOnClick() 
	{
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Main/UI/Menu Selection");
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Main/UI/Menu Selection");
        instance.start();
        instance.release();
    }

	
}
