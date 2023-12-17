using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Punchable : MonoBehaviour
{
    public float minimumVelocity = 1.5f;

    private HandController leftHand;
    private HandController rightHand;
    private DetectVelocity rightHandVelocity;
    private DetectVelocity leftHandVelocity;


    public virtual void Start()
    {
        leftHand = GameObject.Find("LeftController").GetComponent<HandController>();
        rightHand = GameObject.Find("RightController").GetComponent<HandController>();
        rightHandVelocity = rightHand.GetComponent<DetectVelocity>();
        leftHandVelocity = leftHand.GetComponent<DetectVelocity>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabber"))
        {
            if (checkFists(rightHand,other) || checkFists(leftHand, other))
            {
                if (checkVelocity())
                {
                    punched();
                }
                else
                {
                    Debug.Log("You weakling");
                }

            }
        }
    }
    public virtual void punched()
    {
        GameManager.Instance.objectWasPunched?.Invoke();
    }
    private bool checkVelocity()
    {
        if(rightHandVelocity != null || leftHandVelocity != null)
        {
            if(rightHandVelocity.currentVelocitey > minimumVelocity || leftHandVelocity.currentVelocitey > minimumVelocity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private bool checkFists(HandController Hand, Collider other)
    {
        if(Hand != null)
        {
            if( other.transform.parent.name == Hand.name)
            {
                if (Hand.GripAmount > .8f && Hand.PointAmount < .1f && Hand.ThumbAmount < .1f)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
