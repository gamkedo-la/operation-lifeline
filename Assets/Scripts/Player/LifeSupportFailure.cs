using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LifeSupportFailure : MonoBehaviour
{

    //Script triggered from outside.
    //Requires player to hit the space bar a number of times to repair life support damage
    //Life support health bar slowly drains and player has to get it back above a certain level or the player loses the patient.


    private AstroLanceInput astroLanceInput;

    [SerializeField]
    private float repairStatus = 20;

    [SerializeField]
    private Slider lifeSupportRepairLevel;

    [SerializeField]
    private float lifeSupportLossRate = 1;

    private PlayerHealth playerHealth;

    private void OnEnable()
    {
        lifeSupportRepairLevel.value = 10;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        lifeSupportRepairLevel.value = repairStatus;

        repairStatus -= lifeSupportLossRate * Time.deltaTime;

        if(repairStatus < 0)
        {
            playerHealth.Die();
        }
    }

    public void RegainLife(InputAction.CallbackContext context)
    {
        repairStatus += 10;
        if(repairStatus > 100f)
        {
            repairStatus = 100f;
        }
    }



}
