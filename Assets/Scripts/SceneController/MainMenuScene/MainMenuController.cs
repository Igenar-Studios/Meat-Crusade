using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public RectTransform image;

    public float rangeX, rangeY;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCallback()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    public void settingsCallback()
    {
        //add settings scene
    }

}
