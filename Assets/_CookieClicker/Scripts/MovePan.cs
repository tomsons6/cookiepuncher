using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePan : MonoBehaviour
{
    [SerializeField]
    GameObject pan;

    Vector3 panLocalPosition;

    private void Start()
    {
        panLocalPosition = pan.transform.localPosition;
    }
    public void MovePanUp()
    {
        if (pan.transform.localPosition != new Vector3(panLocalPosition.x, .7f, panLocalPosition.z))
        {
            pan.transform.localPosition = new Vector3(panLocalPosition.x, pan.transform.localPosition.y + .35f, panLocalPosition.z);
        }
    }
    public void MovePanDown()
    {
        if (pan.transform.localPosition != new Vector3(panLocalPosition.x, 0f, panLocalPosition.z))
        {
            pan.transform.localPosition = new Vector3(panLocalPosition.x, pan.transform.localPosition.y - .35f, panLocalPosition.z);
        }
    }
}
