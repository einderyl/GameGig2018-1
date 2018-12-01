using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    enum Lane { A, B };
    private float laneOffset = 2.5f;

    public GameObject Wall;
    public GameObject Puddle;
    public GameObject Spikes;

    public gamemaster gm; 

    public GameObject[] ObstacleSet;

    public List<GameObject> obstacles = new List<GameObject>();
    private long frameCounter = 0;

    void Awake()
    {

        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    void Start()
    {
        ObstacleSet = new GameObject[] { Wall, Puddle, Spikes };
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter++;
        if (frameCounter >= 100)
        {
            spawnRandObjects();
            deleteItems();
            frameCounter = 0;
        }

    }

    public void GameOver(string loser)
    {
        switch (loser)
        {
            case "Player 1":
                gm.GameOver("Player 2");
                break;
            case "Player 2":
                gm.GameOver("Player 1");
                break;
        }
    }


    private void deleteItems()
    {
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle != null && obstacle.transform.position.x < getRightOfScreen() - 10)
            {
                Object.Destroy(obstacle);
            }
        }
    }

    private void spawnRandObjects()
    {
        int roll = Random.Range(1, ObstacleSet.Length); // 1, 2 or 3
        GameObject obj = ObstacleSet[roll];
        Vector3 spawnLoc;

        //choose which lane
        if (Random.Range(0.0f, 1.0f) <= 0.5)
        {
            spawnLoc = getLeftOfScreen(Lane.A);
        }
        else
        {
            spawnLoc = getLeftOfScreen(Lane.B);
        }
        GameObject obstacle = Instantiate(obj, spawnLoc, Quaternion.identity);
        obstacle.transform.parent = transform;
        obstacles.Add(obstacle);
    }


    private Vector3 getLeftOfScreen(Lane lane)
    {
        Vector3 cameraPosition = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 0f));
        cameraPosition.z = 0;
        switch (lane)
        {
            case Lane.A:
                cameraPosition.y = laneOffset;
                break;
            case Lane.B:
                cameraPosition.y = -laneOffset;
                break;
        }
        return cameraPosition;
    }
    private float getRightOfScreen()
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
    }
}