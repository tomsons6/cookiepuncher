using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieAnimation : MonoBehaviour
{
    [SerializeField]
    float animationSpeed = 2f;
    [SerializeField]
    float CookieSize = 1.1f;
    Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
    }
    
    public IEnumerator PunchAnimation()
    {

        float t = 0f;
        while(t <= 1f)
        {
            t += Time.deltaTime / animationSpeed;
            Vector3 currentSize = Vector3.Lerp(startScale, startScale * CookieSize,t);

            transform.localScale = currentSize;
            yield return null;
        }
        transform.localScale = startScale; 
    }
}
