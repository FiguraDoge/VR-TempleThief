using UnityEngine;

public class Interactable : MonoBehaviour
{
    // the distance for player be able to pick up
    public float radius = 3f;

    public virtual void Interact()
    {
        Debug.Log("Interact");
    }


    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    */
}
