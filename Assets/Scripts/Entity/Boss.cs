using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity
{

    public PlayerController player;

    public float moveSpeed = 5f;

    public float playerToleranceDiscover = 5f;
    public float playerToleranceChase = 10f;
    public float playerToleranceAttack = 2f;

    private bool foundPlayer = false;

    public float damageMin = 10;
    public float damageMax = 20;

    public float attackCooldown = 500;

    private float lastAttack = 0f;

    private float rotX;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rotX = transform.eulerAngles.x;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        base.Update();
        transform.eulerAngles = new Vector3(
            rotX,
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
        if (!foundPlayer)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= playerToleranceDiscover)
            {
                transform.LookAt(player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                foundPlayer = true;
            }
            else
            {
                foundPlayer = false;
            }
        }
        else {
            if (Vector3.Distance(player.transform.position, transform.position) <= playerToleranceAttack)
            {
                transform.LookAt(player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                foundPlayer = true;
            }
            else if (Vector3.Distance(player.transform.position, transform.position) <= playerToleranceChase)
            {
                transform.LookAt(player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                foundPlayer = true;
                if (Time.time - lastAttack >= attackCooldown / 1000f)
                {
                    player.health -= Random.Range(damageMin, damageMax);
                    lastAttack = Time.time;
                }
            } 
            else 
            {
                foundPlayer = false;
            }
        }
        if (health <= 0)
        {
            // die
            gameObject.SetActive(false);
        }
    }
}
