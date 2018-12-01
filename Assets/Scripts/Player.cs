using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum Lane
    {
        Top,
        Bottom,
    }

    public float _speed = 10f; // TODO: replace with game default speed gameLogic.instance._defaultspeed
    public float _swapspeed = 100f; // TODO: replace with game default speed gameLogic.instance._defaultswapspeed
    public Lane _lane = Lane.Top;
    private int _health = 1000; // TODO: replace all instances with gameLogic.instance._defaulthealth
    private float _damageMultiplier = 1f; // 0f for immunity  / * >1f for boosted dmg etc
    private float _damageMultiplierTimeOut;

	// Update is called once per frame
	void Update () {
		if (_health <= 0) {
            return; // TODO: replace with game end scene
        }

        // Testing function
        if (Input.GetKeyDown("space")) {
            swapLanes();
        }

        // Moves along lane
        var curr_pos = transform.position;
        transform.position += _speed * Vector3.right * Time.deltaTime;

        // Move lanes if necessary
        if (_lane == Lane.Bottom && curr_pos.y > -2.5) {
            transform.position += _swapspeed * Vector3.down * Time.deltaTime;
            if (transform.position.y < -2.5f)
            {
                Vector3 pos = transform.position;
                pos.y = -2.5f;
                transform.position = pos;
            }
        }
        if (_lane == Lane.Top && curr_pos.y < 2.5)
        {
            transform.position += _swapspeed * Vector3.up * Time.deltaTime;
            if (transform.position.y > 2.5f)
            {
                Vector3 pos = transform.position;
                pos.y = 2.5f;
                transform.position = pos;
            }
        }

    }


    // Main functions to call
    public void subtractHealth(int x) {
        _health -= (int) (x * _damageMultiplier);
    }

    public void setDamageMultiplier(float multiplier, float timeout) {
        _damageMultiplier *= multiplier;
        Invoke("getRidOfDamageMultiplier", timeout); // After timeout ms reset dmg multiplier to 1.0f

    }

    public void setSpeedMultiplier(float multiplier, float timeout)
    {
        _speed /= multiplier;
        Invoke("getRidOfSpeedMultiplier", timeout); // After timeout ms reset speed to default speed

    }

    public void swapLanes()
    {
        switch (_lane)
        {
            case Lane.Top:
                _lane = Lane.Bottom;
                break;
            case Lane.Bottom:
                _lane = Lane.Top;
                break;
        }
    }


    // Private helper functions
    private void getRidOfDamageMultiplier() {
        _damageMultiplier = 1.0f;
    }

    void getRidOfSpeedMultiplier() {
        _speed = 10.0f;
    }
  
}
