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
        if (transform.position.x < getRightOfScreen()- 50)
        {
            Object.Destroy(this);
        }
	}
    // On Collision with any of the players
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            var hit = other.gameObject;
            var health = other.gameObject.GetComponent<Player>();
            health.subtractHealth(100);
            other.gameObject.GetComponent<Player>().setSpeedMultiplier(50f, .5f);

        }
    }
    private float getRightOfScreen()
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
    }
}
