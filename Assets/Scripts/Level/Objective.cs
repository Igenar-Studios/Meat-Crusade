using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void ObjectivePassed()
    {

    }

    public virtual bool Condition()
    {
        return false;
    }

    public virtual string ObjectiveString()
    {
        return "Pass Objective";
    }

}
