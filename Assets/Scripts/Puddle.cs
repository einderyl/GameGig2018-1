using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : Obstacle {

	// Use this for initialization
	void Start () {
        this.DAMAGE = 10;
        this.SPEED_MULTIPLIER = 50f;
        this.SPEED_TIMEOUT = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
