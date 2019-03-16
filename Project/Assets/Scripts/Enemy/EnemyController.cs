using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    public float lookRadius = 10f;
    private float attackCoolDown = 0f;
    public float attackRange;

    Transform target;
    NavMeshAgent agent;

    private Animator anim;
    int attackHash = Animator.StringToHash("Attack01");

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        anim = GetComponent<Animator>();
        anim.SetInteger("toDo", 6);     //From stand to walks
        GotoNextPoint();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // In to attack model
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= attackRange)
            {
                // Attck the target
                attackTarget();
                attackCoolDown -= Time.deltaTime;
                // Face the target
                FaceTarget();
            }
        }
        // In to partol model
        else if (!agent.pathPending && agent.remainingDistance < 2f)
        {
            anim.SetInteger("toDo", 6);     //From stand to walk
            GotoNextPoint();
        }

    }

    void attackTarget()
    {
        if (attackCoolDown <= 0f)
        {
            anim.SetInteger("toDo", 9);     // From walk to attack
            HP.instance.modifyHP(-1);
            Debug.Log("Deals 1 damage");
            attackCoolDown = 1.5f;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void GotoNextPoint()
    {
        //anim.SetInteger("toDo", 6);     //From stand to walks
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
}
