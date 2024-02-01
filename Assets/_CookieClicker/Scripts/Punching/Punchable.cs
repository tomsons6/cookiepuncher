using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Punchable : MonoBehaviour
{
    [SerializeField]
    float minimumVelocity = 1.5f;
    HandController leftHand;
    HandController rightHand;
    DetectVelocity rightHandVelocity;
    DetectVelocity leftHandVelocity;
    AudioSource audioSource;

    public bool autoFist = false;

    public virtual void Start()
    {
        leftHand = GameObject.Find("LeftController").GetComponent<HandController>();
        rightHand = GameObject.Find("RightController").GetComponent<HandController>();
        rightHandVelocity = rightHand.GetComponent<DetectVelocity>();
        leftHandVelocity = leftHand.GetComponent<DetectVelocity>();
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabber"))
        {
            if (autoFist)
            {
                PunchWithChecks(other);
            }
            else
            {
                if (checkFists(rightHand, other) || checkFists(leftHand, other))
                {
                    PunchWithChecks(other);
                }
            }
        }
    }
    void PunchWithChecks(Collider other)
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
    public virtual void punched()
    {
        GameManager.Instance.objectWasPunched?.Invoke();
        PlaySound();
    }
    private bool checkVelocity()
    {
        if (rightHandVelocity != null || leftHandVelocity != null)
        {
            if (rightHandVelocity.currentVelocitey > minimumVelocity || leftHandVelocity.currentVelocitey > minimumVelocity)
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
    public bool checkFists(HandController Hand, Collider other)
    {
        if (Hand != null)
        {
            if (other.transform.parent.name == Hand.name)
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
    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
