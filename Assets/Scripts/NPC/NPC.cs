using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{ 

    public enum NPCState
    {
        Resting = 0,

        Chasing = 1,

        Relocating = 2,

        Attacking = 3,

        Dead = 4
    }

    public NPCState state = NPCState.Resting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Resting()
    {

    }

    public virtual void Chasing()
    {

    }

    public virtual void Relocating()
    {

    }

}
