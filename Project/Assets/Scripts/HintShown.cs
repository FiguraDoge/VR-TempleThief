using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintShown : MonoBehaviour
{
    public Transform obj;
    private Vector3 prevPosition;

    void Start()
    {
        prevPosition = obj.position;
    }

    void Update()
    {
        if (obj == null || obj.position != prevPosition)
            Destroy(this.gameObject);
    }

}
