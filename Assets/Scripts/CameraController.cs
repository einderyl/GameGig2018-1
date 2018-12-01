using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{

    public Player _player1;
    public Player _player2;
    private GameObject player1;
    private GameObject player2;
    private float player1_pos;
    private float player2_pos;
    private float back;
    private float front;
    private float MINIMUM_FOV;
    private float lerpTimer;
    private float smooth = 2.0f;
    public Camera myCamera;
    private Coroutine zoomCoroutine;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        player1 = _player1.gameObject;
        player2 = _player2.gameObject;
        offset = transform.position - player1.transform.position;
        MINIMUM_FOV = Camera.main.fieldOfView;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        player1_pos = player1.transform.position.x;
        player2_pos = player2.transform.position.x;
        if (player1_pos < player2_pos)
        {
            back = player1_pos;
            front = player2_pos;
        }
        else
        {
            back = player2_pos;
            front = player1_pos;
        }
        if (Mathf.Abs(player1_pos - player2_pos) < 5)
        {
            if (Mathf.Abs(player1.transform.position.y - player2.transform.position.y) < 5)
            {
                if (player1.transform.position.y == 2.5f)
                {
                    _player2.swapLanes();
                } else if (player1.transform.position.y == -2.5f)
                {
                    _player1.swapLanes();
                }
            }
        }
        front += 50f;
        var zoom_distance = (front - back) / 5.0f;
        transform.position = new Vector3(back, transform.position.y, transform.position.z);
        myCamera.orthographicSize = 5.6f + zoom_distance;
    }

    IEnumerator lerpFieldOfView(Camera targetCamera, float toFOV, float duration)
    {
        float counter = 0;

        float fromFOV = targetCamera.fieldOfView;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float fOVTime = counter / duration;
            Debug.Log(fOVTime);

            //Change FOV
            targetCamera.fieldOfView = Mathf.Lerp(fromFOV, toFOV, fOVTime);
            //Wait for a frame
            yield return null;
        }
    }

}

