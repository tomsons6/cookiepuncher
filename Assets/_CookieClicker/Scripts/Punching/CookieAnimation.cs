using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookieAnimation : MonoBehaviour
{
    [SerializeField]
    float animationSpeed = 2f;
    [SerializeField]
    float CookieSize = 1.1f;
    [SerializeField]
    GameObject TextRoot;
    [SerializeField]
    GameObject PlusOneCanva;
    Vector3 startScale;
    Vector3 startLocation;
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
    public IEnumerator PlusOneText()
    {
        GameObject tempObj = Instantiate(PlusOneCanva, TextRoot.transform);
        tempObj.GetComponentInChildren<TMP_Text>().text = "+" + GameManager.Instance.playerStats.punchStrenght.ToString();
        startLocation = tempObj.transform.localPosition;
        float t = 0f;
        while(t <= 1f)
        {
            t += Time.deltaTime / (animationSpeed + .4f);
            Vector3 currentLocation = Vector3.Lerp(startLocation, new Vector3(startLocation.x, startLocation.y + .5f, startLocation.z), t);
            tempObj.transform.localPosition = currentLocation;
            yield return null;

        }
        Destroy(tempObj);
    }
}
