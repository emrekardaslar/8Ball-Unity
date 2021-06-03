using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackBall : Ball
{
    public GameObject gameOver;
    public Button newGame;
    public Button mainMenu;
    public Button exit;
    public Text winner;

    public override void OnHole()
    {
        if (GameMaster.instance.solidCanHitBlack && GameMaster.instance.solid)
        {
            Destroy(gameObject);
            ShowGameOverPanel("Solid");
        }

        else if (GameMaster.instance.stripesCanHitBlack && GameMaster.instance.stripe)
        {
            Destroy(gameObject);        
            ShowGameOverPanel("Striped");
        }

        else
        {
            Destroy(gameObject);
            if (GameMaster.instance.stripe)
                ShowGameOverPanel("Solid");
            else if (GameMaster.instance.solid)
                ShowGameOverPanel("Striped");
            else
                ShowGameOverPanel("No One");
        }
    }

    private void ShowGameOverPanel(string win)
    {
        GameMaster.instance.paused = true;
        Time.timeScale = 0f;
        winner.text = win + " Won!";
        newGame.onClick.AddListener(() => SceneManager.LoadScene("Billard"));
        mainMenu.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        exit.onClick.AddListener(() => Application.Quit());
        gameOver.SetActive(true);
    }
}
