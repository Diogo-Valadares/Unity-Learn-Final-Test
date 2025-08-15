using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    private void Awake()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score",0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
