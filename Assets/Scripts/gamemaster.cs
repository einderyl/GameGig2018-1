using UnityEngine;
using UnityEngine.UI;

public class gamemaster : MonoBehaviour {

    public GameObject gameStartPanel;
    public Text gameOverText;
    public Button gameStartButton;

    private void Awake ()
    {
        gameStartPanel.SetActive(true);
        gameStartButton.gameObject.SetActive(true);
    }

    public void startGame()
    {
        gameStartPanel.SetActive(false);
        gameStartButton.gameObject.SetActive(false);
        // gameController.instance.startGame();
    }


    public void GameOver (string playerName)
    {
        gameOverText.text = playerName + " wins! Play again?";
        gameStartPanel.SetActive(true);
        gameStartButton.gameObject.SetActive(true);
        gameStartButton.enabled = true;
    }


}