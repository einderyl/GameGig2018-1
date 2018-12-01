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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var hit = other.gameObject;
            var player = other.gameObject.GetComponent<Player>();
            player.Hit(DAMAGE, SPEED_MULTIPLIER, SPEED_TIMEOUT);

            Vector2 pos = new Vector2(-20.0f, 0.0f);
            transform.position = pos;
        }
    }
}
