using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovUpDown : MonoBehaviour
{
//▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
//▌CONTROL MOV HIGHER - LOWER ▐
//▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
//public float amp;
//▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
//▌CONTROL MOV SPEED ▐
//▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
//public float freq;
    Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time/* * freq*/) /* amp*/ + initPos.y, 0);
    }
}
