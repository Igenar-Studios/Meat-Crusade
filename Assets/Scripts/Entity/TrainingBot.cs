using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainingBot : Entity
{

    public TMP_Text healthText;
    private float totalHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = 9999;
    }

    // Update is called once per frame
    void Update()
    {
        totalHealth += 9999 - health;
        healthText.text = ((int) totalHealth).ToString();
    }


}
