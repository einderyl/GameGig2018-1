using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    enum Lane { A, B };
    private float laneOffset = 2.5f;

    public GameObject Wall;
    public GameObject Puddle;
    public GameObject Spikes;
    public long frameCounter = 0;

    public Player A;
    public Player B;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        frameCounter++;
        Debug.Log(frameCounter);
        if(frameCounter >= 50)
        {
            spawnRandObjects();
            frameCounter = 0;
        }
	}

    private void spawnRandObjects()
    {
        GameObject obj;
        float objectQuantifier = Random.Range(0.0f, 3.0f);
        
        //choose which object type (uniform for now)
        if (objectQuantifier <= 1.0)
        {
            obj = Wall;
        }
        else if (objectQuantifier <= 2.0)
        {
            obj = Puddle;
        }
        else
        {
            obj = Spikes;
        }
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
        Track.instance.spawnObstacle(obj, spawnLoc);

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