using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private BoxCollider2D HospitalHelipadBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        HospitalHelipadBoxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D HospitalHelipadBoxCollider)
    {
        Debug.Log("hosipital helipad crossing detected");
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
}
