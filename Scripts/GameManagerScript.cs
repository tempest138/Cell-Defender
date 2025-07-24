using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScoreText;

    public static GameManagerScript instance;

    public TextMeshProUGUI currentScore;

    public GameObject gameOverUI;
    public GameObject winUI;

    int total = 20;
    int current = 0;

    void Start()
    {
        currentScore.text = "Score: " + current.ToString();

        updateHighScore();
    }

    void Update()
    {
        /*if (current == total)
        {
            win();
        }*/
    }

    private void Awake()
    {
        instance = this;
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void win(){
        winUI.SetActive(true);
    }

    public void addPoint()
    {
        current += 1;
        currentScore.text = "Score: " + current.ToString();

        checkHighScore();
    }

    void checkHighScore()
    {
        if (current > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", current);

            updateHighScore();
        }
    }

    void updateHighScore()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
