using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    public float _speed = 2.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
    public void slowDown(float percent)
    {
        _speed = percent / 100.0f * _speed;
    }
}
