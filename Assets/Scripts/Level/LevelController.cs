using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public List<Objective> objectives = new List<Objective>();
    public int objectiveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        Objective objective = objectives[objectiveIndex];
        if (objective.Condition())
        {
            objective.ObjectivePassed();
            NextObjective();
        }
    }

    public virtual void EndLevel()
    {

    }

    public void NextObjective()
    {
        if (objectiveIndex >= objectives.Count - 1)
        {
            EndLevel();
        } 
        else
        {
            objectiveIndex++;
        }
    }

}
