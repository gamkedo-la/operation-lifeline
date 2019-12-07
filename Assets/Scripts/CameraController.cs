using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float followAhead;

    private Vector3 targetPosition;

    public float smoothing; //allows for a less jumpy camera when the target object "turns around"

    public bool followTarget;

    // Use this for initialization
    void Start()
    {
        followTarget = true;
    }

    void Update()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        if (followTarget)
        {
            targetPosition = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);

            
                targetPosition = new Vector3(targetPosition.x, targetPosition.y + followAhead, targetPosition.z);
            

            // transform.position = targetPosition;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
