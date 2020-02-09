using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RuntimeManager.PauseAllEvents(false);
        RuntimeManager.MuteAllEvents(false);
    }


}
