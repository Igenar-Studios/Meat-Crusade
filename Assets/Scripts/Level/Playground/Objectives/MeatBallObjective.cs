using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBallObjective : Objective
{

    public PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        name = "Grab Meatball";
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
        List<Object> contents = inventory.GetContents();
        foreach (Object obj in contents)
        {
            if (obj.GetComponent<Meatball>() != null)
            {
                return true;
            }
        }
        return false;
    }

    public override string ObjectiveString()
    {
        return "Pick Up Meatball";
    }

}
