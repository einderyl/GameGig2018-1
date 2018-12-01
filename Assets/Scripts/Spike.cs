using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Obstacle {

	// Use this for initialization
	void Start () {
        this.DAMAGE = 50;
        this.SPEED_MULTIPLIER = 10f;
        this.SPEED_TIMEOUT = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
