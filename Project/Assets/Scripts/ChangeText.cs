using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeText : MonoBehaviour
{

    public Transform target;    // the trigger
    private Text text;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= range)
        {
            text.text = "You Escaped!!\n Thx for playing!";
        }
    }
}
