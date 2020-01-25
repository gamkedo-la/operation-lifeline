using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectToMap = null;

    [SerializeField]
    string gameObjectName = "";

    //[SerializeField]
    //private Button thisButton = null;
    
    void Start()
    {
        gameObjectToMap = GameObject.Find(gameObjectName);

    }

    //TODO: automatically bind to gameobject and use proper function.  Whenver a persistant Game Object like Paint Job is detached from Buttons in Scene
    // it breaks the button connections and they are not reestablished if the player comes back into the scene.  Hoping to fix that here. 


}
