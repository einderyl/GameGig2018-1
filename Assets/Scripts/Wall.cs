using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacle {

	// Use this for initialization
	void Start () {
        this.DAMAGE = 10;
        this.SPEED_MULTIPLIER = 25f;
        this.SPEED_TIMEOUT = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
