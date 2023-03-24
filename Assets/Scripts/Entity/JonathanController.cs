using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JonathanController : Entity
{

    public NavMeshAgent agent;

    public Transform player;

    public Vector3 walkPoint;
    private bool walkPointSet;

    public float walkPointRange;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;

    public float timeBetweenAttacks = 20;
    private bool attackedAlready;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator animator;

    public Rigidbody rb;

    public MeshCollider meshCollider;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            animator.SetTrigger("DeathTrigger");
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            return;
        }

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        if (rb.velocity != new Vector3(0, 0, 0))
        {
            animator.SetBool("isRunning", true);
        } 
        else
        {
            animator.SetBool("isRunning", false);
        }
        meshCollider.transform.rotation = transform.rotation;
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        } else
        {
            agent.SetDestination(walkPoint);
        }
    }

    private void SearchWalkPoint()
    {
       
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
        if (!attackedAlready)
        {
            //attack code here
            attackedAlready = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        attackedAlready = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Meatball>(out Meatball meatball))
        {
            meatball.enabled = false;
            health -= 500;
        }
    }

}

