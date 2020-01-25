using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    [SerializeField] private string nextLevelSceneName = null;
    private BoxCollider2D colHomeBase;    

    // Start is called before the first frame update
    void Start()
    {
        colHomeBase = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D colHomeBase)
    {
        Debug.Log("hosipital helipad crossing detected");
        GameManager.Instance.LoadScene(nextLevelSceneName);
    }
}