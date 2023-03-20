using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string scene = PlayerPrefs.GetString("NextScene");
        SceneManager.LoadScene(scene);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
