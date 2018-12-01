using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    enum Lane { A, B };
    private float laneOffset = 2.5f;
    
    // Use this for initialization
    void Start () {
        Vector3 spawnLoc = getLeftOfScreen(Lane.A);
        Track.instance.spawnWall(spawnLoc);
    }
	
	// Update is called once per frame
	void Update () {
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
}
