using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    // Use this for initialization
    protected int DAMAGE;
    protected float SPEED_MULTIPLIER;
    protected float SPEED_TIMEOUT;
	void Start () {
        this.DAMAGE = 100;
        this.SPEED_MULTIPLIER = 50f;
        this.SPEED_TIMEOUT = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	}
    // On Collision with any of the players
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var hit = other.gameObject;
            var player = other.gameObject.GetComponent<Player>();
            player.Hit(DAMAGE, SPEED_MULTIPLIER, SPEED_TIMEOUT);
            
        }
    }
}
