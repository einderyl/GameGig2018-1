using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Obstacle {

	// Use this for initialization
	void Start () {
        this.DAMAGE = 0;
        this.SPEED_MULTIPLIER = 0.8f;
        this.SPEED_TIMEOUT = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
