using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public static Track instance;
    public GameObject Wall;
   
    // Use this for initialization
    void Awake () {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void spawnWall(Vector2 loc)
    {
        spawnObstacle(Wall, loc);
    }

    private void spawnObstacle(GameObject obstacle, Vector2 loc)
    {
        Instantiate(obstacle, loc, Quaternion.identity);
    }
}
