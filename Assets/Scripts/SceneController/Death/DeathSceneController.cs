using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathSceneController : MonoBehaviour
{

    public float fadeDelay = 0.5f;
    public float fadeDuration = 1f;
    public float screenDuration = 3f;

    private float startTime;
    private bool shouldFade = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GetComponent<TextMeshProUGUI>().color = new Color(255f, 0f, 0f, 0f);
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
            Color color = GetComponent<TextMeshProUGUI>().color;
            color.a = alpha;
            GetComponent<TextMeshProUGUI>().color = color;
        }
    }

    void StartFade()
    {
        shouldFade = true;
    }

    void LoadMainMenu()
    {
        PlayerPrefs.SetString("NextScene", "MainMenu");
        SceneManager.LoadScene("Loading");
    }

}

