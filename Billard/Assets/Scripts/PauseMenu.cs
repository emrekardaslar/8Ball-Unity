using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void Start()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameMaster.instance.paused)
            {
                Resume();
                GameMaster.instance.paused = false;
            }
            else
            {
                Pause();
                GameMaster.instance.paused = true;
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameMaster.instance.paused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
  
        GameMaster.instance.paused = false;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Billard");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
