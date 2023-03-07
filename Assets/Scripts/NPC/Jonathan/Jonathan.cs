using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jonathan : NPC
{

    private Transform player;
    public double health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            state = NPCState.Dead;
        }
    }

    public override void Resting()
    {
        //play resting animation
        //fire raycast to find player, if found, switch to chasing and set player transform
    }

    public override void Chasing()
    {
        //chase player and find raycast
        //if raycast not found switch back to resting
    }
}
