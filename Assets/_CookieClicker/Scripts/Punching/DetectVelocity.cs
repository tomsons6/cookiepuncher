using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVelocity : MonoBehaviour
{
    public float currentVelocitey;
    Vector3 previous;

    // Update is called once per frame
    void Update()
    {
        DetermineVelocity();
    }

    void DetermineVelocity()
    {
        currentVelocitey = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;
    }
}
