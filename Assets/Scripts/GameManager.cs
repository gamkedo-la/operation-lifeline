using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Text pauseTextUI;
    [SerializeField] private string pauseText = "GAME PAUSED";

    private GameObject homeBase;
    private GameObject player;
    private float totalJourneyDistanceThisLevel = 0;

    public void SetPause(bool toPause = true) {
        isPaused = toPause;
        pauseTextUI.text = isPaused ? pauseText : "";
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
        SceneManager.LoadScene(sceneName, mode);
        InitializeScene();
    }

    private void Start() {
        pauseTextUI = GetComponentsInChildren<Text>()[0];

        Debug.Log(GetTotalJourneyDistance());

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
    
    private IEnumerator playerPositionUpdate() {
        while (true) {
            Vector3 playerCurrentPosition = player.transform.position;
            Debug.Log(playerCurrentPosition.y / totalJourneyDistanceThisLevel);

            yield return new WaitForSeconds(3);
        }
    }

    private float GetTotalJourneyDistance() {
        float distance = 0;

        if (homeBase && player) {
            distance = (homeBase.transform.position - player.transform.position).magnitude; 
        }

        return distance;
    }
}
