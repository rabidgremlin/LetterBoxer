using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMove : MonoBehaviour {

    public Transform a, b;
    [Range(0, 1)]
    public float speed = 1;

    private Vector3 lastPos;
    public bool faceMovementDirection = false;

    private void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(a.position, b.position, pingPong);

        if (faceMovementDirection)
        {
            if (lastPos.x > transform.position.x )
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            lastPos = transform.position;
        }

    }
}
