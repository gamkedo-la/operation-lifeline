using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MuteAudio : MonoBehaviour
{
    
    public void MuteAllAudio(bool muteToggle)
    {
        Debug.Log("mute called");
        muteToggle = !muteToggle;
        Debug.Log(muteToggle);
        RuntimeManager.MuteAllEvents(muteToggle);
    }
}
