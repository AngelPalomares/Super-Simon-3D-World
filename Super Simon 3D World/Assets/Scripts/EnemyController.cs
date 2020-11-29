using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;

    public int currentPatrolPoint;

    public NavMeshAgent agent;

    public Animator anim;

    public enum AIState
    {
        Idle,Patrolling, Chasing, Attacking
    };

    public AIState current;

    public float PointWait = 2f;
    private float wait;

    public float ChaseRange;

    public float attackRange = 1f;
    public float timeBetweenAttacks = 2f;
    private float attackCounter;


    // Start is called before the first frame update
    void Start()
    {
        wait = PointWait;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        switch (current)
        {
            case AIState.Idle:

                anim.SetBool("Moving", false);

                if(wait > 0)
                {
                    wait -= Time.deltaTime;
                }
                else
                {
                    current = AIState.Patrolling;
                    agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }

                if(Distance <= ChaseRange)
                {
                    current = AIState.Chasing;
                    anim.SetBool("Moving", true);
                }

                break;

            case AIState.Patrolling:

        //agent.SetDestination(patrolPoints[currentPatrolPoint].position);

        if (agent.remainingDistance <= .2f)
        {
            currentPatrolPoint++;
            if (currentPatrolPoint >= patrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }
                    //agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                    current = AIState.Idle;
                    wait = PointWait;
        }

                if (Distance <= ChaseRange)
                {
                    current = AIState.Chasing;
                }

                anim.SetBool("Moving", true);
                break;
            case AIState.Chasing:

                agent.SetDestination(PlayerController.instance.transform.position);

                if(Distance <= attackRange)
                {
                    current = AIState.Attacking;
                    anim.SetTrigger("Attack");
                    anim.SetBool("Moving", false);

                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;

                    attackCounter = timeBetweenAttacks;
                }
                if(Distance > ChaseRange)
                {
                    current = AIState.Idle;
                    wait = PointWait;

                    agent.velocity = Vector3.zero;

                    agent.SetDestination(transform.position);
                }

                break;

            case AIState.Attacking:

                transform.LookAt(PlayerController.instance.transform, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if(attackCounter <= 0)
                {
                    if(Distance < attackRange)
                    {
                        anim.SetTrigger("Attack");
                        attackCounter = timeBetweenAttacks;

                    }
                    else
                    {
                        current = AIState.Idle;
                        wait = PointWait;

                        agent.isStopped = false;
                    }
                }

                break;
    }
    }
}
