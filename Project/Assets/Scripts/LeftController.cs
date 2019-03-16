using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftController: MonoBehaviour
{
    public bool inventoryEnable;
    public GameObject inventory;
    private int allSlots;
    private float cd = 0f;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;


    private bool CheckGrab()
    {
        return grabAction.GetState(handType);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckGrab() && cd <= 0 )
        {
            inventoryEnable = !inventoryEnable;
            cd = 0.5f;
        }

        if (inventoryEnable == true)
        {
            inventory.SetActive(true);
        } else
        {
            inventory.SetActive(false);
        }

        cd -= Time.deltaTime;
    }
}
