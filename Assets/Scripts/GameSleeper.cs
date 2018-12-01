using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSleeper : MonoBehaviour {

    public Player A;
    public Player B;
    public Track track;
    public GameController gc;

    // Use this for initialization
    private void Start()
    {
        sleepGame();
    }

    public void sleepGame ()
    {
        A.gameObject.SetActive(false);
        B.gameObject.SetActive(false);
        track.gameObject.SetActive(false);
        gc.gameObject.SetActive(false);
    }

    public void wakeGame()
    {
        A.gameObject.SetActive(true);
        B.gameObject.SetActive(true);
        track.gameObject.SetActive(true);
        gc.gameObject.SetActive(true);
    }
	
	public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
