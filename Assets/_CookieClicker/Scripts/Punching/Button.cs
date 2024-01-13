using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Punchable
{
    MovePan movePan;
    private enum buttonFunction { buttonUp, buttonDown };
    [SerializeField]
    buttonFunction buttonFnc;
    Vector3 startLocalPosition;
    [SerializeField]
    float animationSpeed;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        movePan = GetComponentInParent<MovePan>();
        startLocalPosition = transform.localPosition;
    }

    public override void punched()
    {
        base.punched();
        switch(buttonFnc)
        {
            case buttonFunction.buttonUp:
                movePan.MovePanUp();
                break; 
            case buttonFunction.buttonDown:
                movePan.MovePanDown();
                break;
        }
        StartCoroutine(ButtonAnimation());
    }
    IEnumerator ButtonAnimation()
    {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / animationSpeed;
            Vector3 currentButtonPosition = Vector3.Lerp(startLocalPosition, new Vector3(1.791f, startLocalPosition.y, 3.969f), t);
            transform.localPosition = currentButtonPosition;
            yield return null;
        }
        transform.localPosition = startLocalPosition;
    }
}
