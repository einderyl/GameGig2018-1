using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public RectTransform _healthBar;
    public enum Lane
    {
        Top,
        Bottom,
    }

    private float startingSpeed = 20.0f;

    public float _speed = 20.0f; // TODO: replace with game default speed gameLogic.instance._defaultspeed
    public float _swapspeed = 100f; // TODO: replace with game default speed gameLogic.instance._defaultswapspeed
    public Lane _lane = Lane.Top;

    private bool _damaged = false;
    private bool _swapping = false;
    private int _health = 100; // TODO: replace all instances with gameLogic.instance._defaulthealth
    private float _damageMultiplier = 1f; // 0f for immunity  / * >1f for boosted dmg etc
    private float _damageMultiplierTimeOut;

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            GameController.instance.GameOver(this.name);
            return; // TODO: replace with game end scene
        }

        // Testing function
        if (Input.GetKeyDown("space"))
        {
            swapLanes();
        }

        // Moves along lane
        var curr_pos = transform.position;
        transform.position += _speed * Vector3.right * Time.deltaTime;

        // Move lanes if necessary
        if (_lane == Lane.Bottom && curr_pos.y > -2.5)
        {
            transform.position += _swapspeed * Vector3.down * Time.deltaTime;
            if (transform.position.y < -2.5f)
            {
                Vector3 pos = transform.position;
                pos.y = -2.5f;
                transform.position = pos;
                _swapping = false;
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
                _swapping = false;
            }
        }

    }
    
    // Main functions to call
    public void Hit(int damage, float speedMultiplier, float duration)
    {
        _damaged = true;
        subtractHealth(damage);
        setSpeedMultiplier(speedMultiplier, duration);

        //Set alpha to 0.5f
        SpriteRenderer spRend = transform.GetComponent<SpriteRenderer>();
        Color col = spRend.color;
        col.a = 0.5f;
        spRend.color = col;
    }
    public void subtractHealth(int x)
    {
        _health -= (int)(x * _damageMultiplier);
        _healthBar.sizeDelta = new Vector2(_health, _healthBar.sizeDelta.y);
    }

    public void setDamageMultiplier(float multiplier, float timeout)
    {
        _damageMultiplier *= multiplier;
        Invoke("getRidOfDamageMultiplier", timeout); // After timeout ms reset dmg multiplier to 1.0f
    }

    public void setSpeedMultiplier(float multiplier, float timeout)
    {
        _speed /= multiplier;
        Invoke("getRidOfSpeedMultiplier", timeout); // After timeout ms reset speed to default speed
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !_swapping)
        {
            swapLanes();
        }
    }
    public void swapLanes()
    {
        if (_damaged) { return; }
        switch (_lane)
        {
            case Lane.Top:
                _lane = Lane.Bottom;
                break;
            case Lane.Bottom:
                _lane = Lane.Top;
                break;
        }
        _swapping = true;
    }

    // Private helper functions
    private void getRidOfDamageMultiplier()
    {
        _damageMultiplier = 1.0f;
    }

    private void getRidOfSpeedMultiplier()
    {
        _speed = startingSpeed;
        _damaged = false;
        //Set alpha to 1.0f
        SpriteRenderer spRend = transform.GetComponent<SpriteRenderer>();
        Color col = spRend.color;
        col.a = 1.0f;
        spRend.color = col;
    }

}
