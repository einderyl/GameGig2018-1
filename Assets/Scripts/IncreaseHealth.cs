using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : Obstacle {

	// Use this for initialization
	void Start () {
        this.DAMAGE = -25;
        this.SPEED_MULTIPLIER = 1.0f;
        this.SPEED_TIMEOUT = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
