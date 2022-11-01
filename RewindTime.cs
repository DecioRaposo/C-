using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    private bool isRewinding = false;

    public float maxRecordingTime = 5f;
    
    List<PointInTime> pointsInTime;

    Rigidbody rb;

    private Vector3 startPos;

    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartRewind();
        if (Input.GetKeyUp(KeyCode.Space)) StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
        {
            prevPos = transform.position;

            // Record only if object changes position (ignoring y axis for animation)
            if (prevPos.x != startPos.x || prevPos.z != startPos.z) Record();
        }
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        float maxRecordingPoints =
            Mathf.Round(maxRecordingTime / Time.fixedDeltaTime);
        if (pointsInTime.Count < maxRecordingPoints)
        {
            Debug.Log("recording....");
            pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
        else
        {
            Debug.Log("max recorded time reached....");
        }
    }

    public void StartRewind()
    {
        //Only rewind if has recorded
        if (pointsInTime.Count > 0)
        {
            Debug.Log("rewinding...");
            isRewinding = true;
            rb.isKinematic = true;
        }
    }

    public void StopRewind()
    {
        pointsInTime = new List<PointInTime>(); //Clear the list to avoid buffering increase
        isRewinding = false;
        // Keeping isKinematic for example for floating objects that should not have gravity
        // rb.isKinematic = false;
    }
}
