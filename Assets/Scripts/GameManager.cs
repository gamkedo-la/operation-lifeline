using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start() {
        pauseTextUI = GetComponentsInChildren<Text>()[0];
    }
}
