using UnityEngine;
using UnityEngine.UI;

public class gamemaster : MonoBehaviour {

    public GameObject gameStartPanel;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public Button gameStartButton;
    public Button gameOverButton;
    public Button RageQuitButton;
    public Button pauseButton;

    private void Awake ()
    {
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameStartButton.gameObject.SetActive(true);
        RageQuitButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void startGame()
    {
        gameStartPanel.SetActive(false);

        gameStartButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        RageQuitButton.gameObject.SetActive(true);
        
    }

    public void pauseGame()
    {
        gameOverText.text = "Pausing";
        gameStartPanel.SetActive(true);
        gameStartButton.gameObject.SetActive(true);
        gameStartButton.enabled = true;
    }

    public void GameOver (string s)
    {
        gameOverText.text = s;
        gameOverPanel.SetActive(true);
        gameOverButton.gameObject.SetActive(true);
        gameOverButton.enabled = true;
    }




}