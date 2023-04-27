using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashController : MonoBehaviour
{

    public float fadeDelay = 0.5f;
    public float fadeDuration = 1f;
    public float screenDuration = 3f;

    private float startTime;
    private bool shouldFade = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        startTime = Time.time;
        Invoke("LoadMainMenu", screenDuration);
        Invoke("StartFade", fadeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFade)
        {
            float elapsedTime = Time.time - startTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            Color color = GetComponent<Image>().color;
            color.a = alpha;
            GetComponent<Image>().color = color;
        }
    }

    void StartFade()
    {
        shouldFade = true;
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
