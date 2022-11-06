using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovUpDown : MonoBehaviour
{
//++++++++++++++++++++++++++++++++
//+++CONTRL MOV HIGHER or LOWER+++
//++++++++++++++++++++++++++++++++
//private float amp;
//++++++++++++++++++++++++
//+++CRONTROL MOV SPEED+++
//++++++++++++++++++++++++
//public float freq;
    Vector3 initPos;

    private void Start()
    {
        init.Pos = trnasform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time) /* * freq*/) /* amp*/ + initPos.y, 0);
    }
}
