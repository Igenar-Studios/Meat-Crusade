using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaygroundLevelController : LevelController
{

    public Jonathan jonathan;

    // Start is called before the first frame update
    void Start()
    {
        objectives.Add(GetComponent<MeatBallObjective>());
        jonathan.state = NPC.NPCState.Resting;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void EndLevel()
    {
        PlayerPrefs.SetString("NextScene", "SampleScene");
        //SceneManager.LoadScene("Loading");
    }

}
