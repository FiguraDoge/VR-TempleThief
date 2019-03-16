using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC : MonoBehaviour
{
    public Transform C;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        FaceTarget();
        transform.position = C.position;
        transform.position += new Vector3(C.transform.forward.x, C.transform.forward.y - 0.5f, C.transform.forward.z * 2.5f);
    }

    void FaceTarget()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
