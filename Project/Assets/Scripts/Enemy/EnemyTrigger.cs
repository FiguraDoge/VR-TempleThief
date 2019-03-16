using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    // the object we want to spawn
    public GameObject[] enemy;

    public void trigger()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].SetActive(true);
        }
    }
}
