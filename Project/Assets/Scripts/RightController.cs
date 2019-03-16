using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightController : MonoBehaviour
{
    #region Singleton
    public static RightController instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public SteamVR_Input_Sources handType; 
    public SteamVR_Action_Boolean walkAction;
    public SteamVR_Action_Boolean grabAction;

    public float walkSpeed;

    public float speedBuff;
    public float speedBuffTime;         // Check speed buff time

    private bool CheckWalk()
    {
        return walkAction.GetState(handType);
    }

    private bool CheckGrab()
    {
        return grabAction.GetState(handType);
    }

    private void CheckSpeedBuff()
    {
        if (speedBuffTime > 0)
            speedBuffTime -= Time.deltaTime;
        else
            speedBuff = 0f;
    }

    void Update()
    {
        CheckSpeedBuff();

        // Interact Check
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
        {

            // If player hit an interactable item
            ItemPickUp IPU = hit.collider.GetComponent<ItemPickUp>();

            // The object is indeed interactable or not
            if (IPU != null)
            {
                // If it is, check whether player is in pickable range
                if (hit.distance <= IPU.radius)
                {
                    if (CheckGrab())
                    {
                        IPU.Interact();
                    }
                }
            }

        }

        // Check Walk
        if (CheckWalk())
        {
            Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z);
            transform.parent.parent.position += Vector3.Normalize(dir) * (walkSpeed + speedBuff) * Time.deltaTime;
        }
       
    }
}
