using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillJonathanObjective : Objective
{

    public JonathanController jonathan;

    // Start is called before the first frame update
    void Start()
    {
        name = "Kill Jonathan";
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
        if (!isEnabled) return false;
        return jonathan.health <= 0;
    }

    public override string ObjectiveString()
    {
        return "Kill Jonathan";
    }

}
