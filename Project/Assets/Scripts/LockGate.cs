using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGate : MonoBehaviour
{
    public float range;
    public Transform Player;
    public int movingSpeed;
    public static bool keyUsed;
    public bool openDoor;

    void Start()
    {
        keyUsed = false;
        openDoor = false;
    }

    public void Update()
    {
        open();
        if (openDoor)
        {
            // lower down the door slowly
            // Starting position <0, 7, -66>
            // End position <0, -9, -66>
            transform.position += Vector3.down * movingSpeed * Time.deltaTime;
        }

        if (transform.position.y <= -9f)
            Destroy(this);
    }

    public void useKey()
    {
        keyUsed = true;
    }

    public void open()
    {
        // the gate will be open when two conditons are satisfied
        // 1. the key is used (this will be called as item.use())
        if (Vector3.Distance(this.transform.position, Player.position) > range)
            keyUsed = false;

        // 2. key(player) is in the range
        if (Vector3.Distance(this.transform.position, Player.position) <= range && keyUsed)
            openDoor =  true;
    }
}
