using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI congratulationsText;
    public TextMeshProUGUI scoreText;
    public Image gameOverPanel;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void Congratulations()
    {
        congratulationsText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
