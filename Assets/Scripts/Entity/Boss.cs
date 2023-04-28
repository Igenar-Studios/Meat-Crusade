using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity
{

    public PlayerController player;

    public float moveSpeed = 5f;

    public float playerToleranceDiscover = 5f;
    public float playerToleranceChase = 10f;

    private bool foundPlayer = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!foundPlayer)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < playerToleranceDiscover)
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
            if (Vector3.Distance(player.transform.position, transform.position) < playerToleranceChase)
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
        if (health <= 0)
        {
            // die
            gameObject.SetActive(false);
        }
    }
}
