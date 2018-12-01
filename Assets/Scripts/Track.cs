using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public static Track instance;
    // Use this for initialization
    void Awake () {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
	// Update is called once per frame
	void Update () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        Vector2 scale = transform.localScale;
        scale.x = cameraSize.x / spriteSize.x;
        Vector3 bgLoc = Camera.main.gameObject.transform.position;
        bgLoc.z = 1;
        transform.position = bgLoc;
        transform.localScale = scale;
    }
}
