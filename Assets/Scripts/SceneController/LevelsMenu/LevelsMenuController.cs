using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void homeCallback()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void rangeCallback()
    {
        SceneManager.LoadScene("Range");
    }

    public void mallCallback()
    {
        SceneManager.LoadScene("Playground");
    }

    public void arbyCallback()
    {
        SceneManager.LoadScene("Arby");
    }

}
