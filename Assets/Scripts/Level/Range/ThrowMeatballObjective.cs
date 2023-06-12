using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMeatballObjective : Objective
{

    public bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Condition()
    {
        if (!isEnabled) return false;
        return thrown;
    }

    public override string ObjectiveString()
    {
        return "Throw Meatball";
    }

}
