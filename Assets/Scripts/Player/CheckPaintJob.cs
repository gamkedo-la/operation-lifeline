using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPaintJob : MonoBehaviour
{
    private CurrentPaintJob currentPaintJob;

    [SerializeField]
    private MeshRenderer playerModel = null;

    void Awake()
    {
        currentPaintJob = FindObjectOfType<CurrentPaintJob>();
		if (currentPaintJob)
		{
            playerModel.material = currentPaintJob.paintJob;
		}
    }


}
