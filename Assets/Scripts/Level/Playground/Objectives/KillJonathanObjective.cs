using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillJonathanObjective : Objective
{

    public Jonathan jonathan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ObjectivePassed()
    {

    }

    public override bool Condition()
    {
        return jonathan.state == NPC.NPCState.Dead;
    }

    public override string ObjectiveString()
    {
        return "Kill Jonathan";
    }

}
