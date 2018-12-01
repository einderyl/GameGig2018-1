using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class player : MonoBehaviour {

    enum lane
    {
        top,
        bottom,
    }

    public float _speed = 10f; // TODO: replace with game default speed gameLogic.instance._defaultspeed
    public float _swapspeed = 100f; // TODO: replace with game default speed gameLogic.instance._defaultswapspeed
    private int _health = 100; // TODO: replace all instances with gameLogic.instance._defaulthealth
    private float _damageMultiplier = 1f; // 0f for immunity  / * >1f for boosted dmg etc
    private float _damageMultiplierTimeOut;
    private lane _lane = lane.top;

	// Update is called once per frame
	void Update () {
		if (_health <= 0) {
            return; // TODO: replace with game end scene
        }

        // Testing function
        if (Input.anyKeyDown)
        {
            swapLanes();
        }

        // Moves along lane
        var curr_pos = transform.position;
        transform.position += _speed * Vector3.right * Time.deltaTime;

        // Move lanes if necessary
        if (_lane == lane.bottom && curr_pos.y > -2.5) {
            transform.position += _swapspeed * Vector3.down * Time.deltaTime;
        }
        if (_lane == lane.top && curr_pos.y < 2.5)
        {
            transform.position += _swapspeed * Vector3.up * Time.deltaTime;
        }

    }


    // Main functions to call
    void subtractHealth(int x) {
        _health -= (int) (x * _damageMultiplier);
    }

    void setDamageMultiplier(float multiplier, float timeout) {
        _damageMultiplier *= multiplier;
        getRidOfDamageMultiplier(timeout); // After timeout ms reset dmg multiplier to 1.0f

    }

    void setSpeedMultiplier(float multiplier, float timeout)
    {
        _speed *= multiplier;
        getRidOfSpeedMultiplier(timeout); // After timeout ms reset speed to default speed

    }

    void swapLanes()
    {
        switch (_lane)
        {
            case lane.top:
                _lane = lane.bottom;
                break;
            case lane.bottom:
                _lane = lane.top;
                break;
        }
    }


    // Private helper functions
    private void getRidOfDamageMultiplier(float timeout) {
        var aTimer = new Timer(timeout); // Note timeout is in milliseconds, eg 1000 is 1 sec
        aTimer.Elapsed += new ElapsedEventHandler(TimerEventDmg);
        aTimer.Enabled = true;
        aTimer.Stop();
        aTimer.Dispose();
    }

    private void TimerEventDmg(object src, ElapsedEventArgs e)
    {
        _damageMultiplier = 1.0f;
    }

    private void getRidOfSpeedMultiplier(float timeout)
    {
        var aTimer = new Timer(timeout); // Note timeout is in milliseconds, eg 1000 is 1 sec
        aTimer.Elapsed += new ElapsedEventHandler(TimerEventSpeed);
        aTimer.Enabled = true;
        aTimer.Stop();
        aTimer.Dispose();
    }

    private void TimerEventSpeed(object src, ElapsedEventArgs e)
    {
        _speed = 10f; // TODO: replace with game default speed gameLogic.instance._defaultspeed
    }

}
