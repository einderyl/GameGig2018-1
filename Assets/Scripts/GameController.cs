using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Vector2 laneA = new Vector2(1.0f, 2.5f);
    private Vector2 laneB = new Vector2(1.0f, -2.5f);

    // Use this for initialization
    void Start () {
        Track.instance.spawnWall(laneB);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
