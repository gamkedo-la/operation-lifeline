using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShake : MonoBehaviour
{

    private bool shouldBeShaking = false;

    [SerializeField]
    private float shakeAmount;

    public void ShakeMe()
    {
        StartCoroutine("runShakeMeFunction");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldBeShaking)
        {
            float thisFramesStartingX = transform.position.x;
            float thisFramesStartingY = transform.position.y;

            float thisFramesXOffset = Random.Range(0.0f, 0.00001f);
            float thisFramesYOffSet = Random.Range(0.0f, 0.00001f);

            float thisFramesNewX = thisFramesStartingX + thisFramesXOffset;
            float thisFramesNewY = thisFramesStartingY + thisFramesYOffSet;

            transform.Translate(thisFramesNewX, thisFramesNewY, 0);
        }
    }

    IEnumerator runShakeMeFunction()
    {
        Vector3 startingAndEndingPosition = transform.position;

        if (!shouldBeShaking)
        {
            shouldBeShaking = true;
        }

        yield return new WaitForSeconds(0.02f);

        shouldBeShaking = false;
        transform.position = startingAndEndingPosition;
    }
}
