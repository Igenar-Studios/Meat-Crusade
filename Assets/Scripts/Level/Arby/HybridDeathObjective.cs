using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HybridDeathObjective : Objective
{

    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        base.name = "Kill Hybrid";
    }

    public override bool Condition()
    {
        if (!isEnabled) return false;
        return boss.health <= 0;
    }

    public override string ObjectiveString()
    {
        return "Kill Hybrid";
    }
         
}
