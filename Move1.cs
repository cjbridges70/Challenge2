using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1: MonoBehaviour { 

    private Vector3 pos1 = new Vector3(-8.506f, -1.51f, 0);
    private Vector3 pos2 = new Vector3(-8.506f, -3.58f, 0);
    public float speed = .25f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}