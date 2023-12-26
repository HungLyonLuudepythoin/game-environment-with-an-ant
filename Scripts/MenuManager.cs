using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public bool gameOver = false;
    [SerializeField]
    private TextMeshProUGUI scoreText, goScoreText;
    [SerializeField]
    private GameObject gameMenu, menu, gameOverMenu;
    public int currentScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 0;
    }


    public void IncreaseScore()
    {
        currentScore++;
        scoreText.text = "" + currentScore;
    }

    public void PlayBtn()
    {
        menu.SetActive(false);
        gameMenu.SetActive(true);
        Player.instance.StartMoving = true;
    }

    public void GameOver()
    {
        SoundManager.instance.PlayDeath();
        gameOver = true;
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        goScoreText.text = "" + currentScore;
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
