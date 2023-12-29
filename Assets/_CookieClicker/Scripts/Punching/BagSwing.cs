using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSwing : Punchable
{
    GameObject pivotPoint;
    public override void Start()
    {
        base.Start();
        pivotPoint = transform.parent.gameObject;

    }
    //public override void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Grabber"))
    //    {
    //        if (checkFists(rightHand, other) || checkFists(leftHand, other))
    //        {
    //            Debug.Log(other.ClosestPointOnBounds(transform.position));
    //            //StartCoroutine(Swing(other));
    //        }
    //    }
    //}

    //IEnumerator Swing(Collider other)
    //{
    //    float inertia = IncomingVelocity(other);
    //    while (inertia >= 0)
    //    {
    //        Vector3 temp = pivotPoint.transform.rotation.eulerAngles;
    //        Debug.Log(temp);
    //        temp.y = Mathf.PingPong(inertia,inertia);
    //        pivotPoint.transform.rotation = Quaternion.Euler(temp);
    //        inertia -= .001f;
    //        yield return null;
    //    }


    //}

    //float IncomingVelocity(Collider other)
    //{
    //    if (other.transform.parent.name == rightHandVelocity.transform.name)
    //    {
    //        Debug.Log("Right hand velocity - " + rightHandVelocity.currentVelocitey);
    //        return rightHandVelocity.currentVelocitey;
    //    }
    //    if (other.transform.parent.name == leftHandVelocity.transform.name)
    //    {
    //        Debug.Log("Left hand velocity - " + leftHandVelocity.currentVelocitey);
    //        return leftHandVelocity.currentVelocitey;
    //    }
    //    return 0;
    //}
}
