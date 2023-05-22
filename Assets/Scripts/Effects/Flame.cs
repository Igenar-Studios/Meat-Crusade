using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{

    public float duration = 30f;
    public float distance = 3f;
    public float damage = 0.5f;

    public void Awake()
    {
        Invoke("Extinguish", duration);
    }

    public void FixedUpdate()
    {
        Entity[] entities;
        entities = GameObject.FindObjectsOfType<Entity>();
        for (int i = 0; i < entities.Length; i++)
        {
            Entity entity = entities[i];
            if (Vector3.Distance(entity.transform.position, transform.position) <= distance)
            {
                entity.health -= damage;
            }
        }
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        if (Vector3.Distance(player.transform.position, transform.position) <= distance)
        {
            player.health -= damage;
        }
    }

    private void Extinguish()
    {
        gameObject.SetActive(false);
    }

}
