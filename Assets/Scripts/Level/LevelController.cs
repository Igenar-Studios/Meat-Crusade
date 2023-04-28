using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    public List<Objective> objectives = new List<Objective>();
    public int objectiveIndex = 0;

    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public Slider sensSlider;

    public PlayerController player;

    public Text currentObjective;

    private bool isPaused = false;
    private bool isSettings = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        sensSlider.value = PlayerPrefs.GetFloat("Sens") * 100;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Objective objective = objectives[objectiveIndex];
        currentObjective.text = objective.name;
        if (objective.Condition())
        {
            objective.ObjectivePassed();
            NextObjective();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        PlayerPrefs.SetFloat("Sens", sensSlider.value);
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

    public void MenuAction()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsAction()
    {
        if (isPaused && !isSettings)
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
            isSettings = true;
        }
    }

    public void PauseAction()
    {
        if (isPaused && isSettings)
        {
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
            isSettings = false;
        }
    }

    private void TogglePause()
    {
        if (isSettings) return;
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
            player.acceptingInput = false;
            isPaused = true;
        } 
        else {
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            player.acceptingInput = true;
            isPaused = false;
        }
    }
}
