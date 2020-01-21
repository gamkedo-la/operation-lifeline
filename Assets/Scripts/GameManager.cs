using System.Collections;
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

	[SerializeField] private GameObject pauseMenu;

    private GameObject homeBase;
    private GameObject player;
    private float totalJourneyDistanceThisLevel = 0;
    [SerializeField] private float progressIndicatorUpdateInterval = 3;
    private Scrollbar progressIndicatorUI;

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

        StartCoroutine(MoveToScene(sceneName, LoadSceneMode.Single));
        /*SceneManager.LoadScene(sceneName, mode);
        InitializeScene();*/
    }

    private void Start() {  
            progressIndicatorUI = GetComponentsInChildren<Scrollbar>()[0];
            InitializeScene();     
    }

    private void InitializeScene() {
        homeBase = GameObject.FindWithTag("HomeBase");
        player = GameObject.FindWithTag("Player");
        totalJourneyDistanceThisLevel = GetTotalJourneyDistance();

        if (homeBase && player) {
            StopCoroutine(playerPositionUpdate());
            StartCoroutine(playerPositionUpdate());
        }
    }

    private IEnumerator MoveToScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        yield return new WaitForSeconds(1);
        if (RuntimeManager.HasBankLoaded("Master"))
        {
            SceneManager.LoadScene(sceneName, mode);
            InitializeScene();

            yield return null;
        }
        else
        {
            StartCoroutine(MoveToScene(sceneName, LoadSceneMode.Single));
        }
    }
    
    private IEnumerator playerPositionUpdate() {
        while (true) {
			if (!player) { break; }
            Vector3 playerCurrentPosition = player.transform.position;
            progressIndicatorUI.value = playerCurrentPosition.y / totalJourneyDistanceThisLevel;

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
		FMODUnity.RuntimeManager.PlayOneShot("event:/Main/UI/Menu Selection");
	}
}
