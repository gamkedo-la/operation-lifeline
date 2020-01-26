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
	private float playerTrackDistance = 150f;

    // Use this for initialization
    void Start()
    {
        followTarget = true;
    }

    void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        if (target && followTarget)
        {
			var x = transform.position.x;
			x = Mathf.Clamp(x, target.transform.position.x - playerTrackDistance, target.transform.position.x + playerTrackDistance);
			//targetPosition = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
			targetPosition = new Vector3(x, target.transform.position.y + followAhead, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }

    public void Shake(float howLongToShake, float howMuchToShake)
    {   
        StopCoroutine(StartShake(howLongToShake, howMuchToShake));     
        StartCoroutine(StartShake(howLongToShake, howMuchToShake));
    }

    private IEnumerator StartShake(float howLongToShake, float howMuchToShake) 
    {
        Vector3 originalPosition = transform.localPosition;        

        for (float howLongAlreadyShaked = 0.0f; howLongAlreadyShaked < howLongToShake; howLongAlreadyShaked += Time.deltaTime)
        {
            float x = Random.Range(-1f, 1f) * howMuchToShake;
            float y = Random.Range(-1f, 1f) * howMuchToShake;

            transform.localPosition = new Vector3(x, targetPosition.y + y, targetPosition.z);    

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
