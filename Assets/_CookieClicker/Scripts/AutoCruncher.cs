using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoCruncher : MonoBehaviour
{    
    public AutoChruncherScriptable stats;
    [SerializeField]
    TMP_Text strenght;
    [SerializeField]
    TMP_Text waitTime;
    [SerializeField]
    GameObject additionAnimation;
    UIController mainCanva;
    [SerializeField]
    float animationSpeed;
    Vector3 startPosition;
    void Start()
    {
        mainCanva = GameObject.Find("MainCanva").GetComponent<UIController>();
        startPosition = additionAnimation.transform.position;
        additionAnimation.SetActive(false);
        UpdateTexts();
        StartCoroutine(AutoCrunch());
    }

    IEnumerator AutoCrunch()
    {
        while (true)
        {
            GameManager.Instance.playerStats.cookieCount += stats.crunchStrenght;
            mainCanva.UpdateText();
            StartCoroutine(textAnimation());
            yield return new WaitForSeconds(stats.waitTime);
        }
    }
    public void UpdateTexts()
    {
        strenght.text = "Crunch strenght - " + string.Format("{0:0.0}", stats.crunchStrenght);
        waitTime.text = "Wait time - " + string.Format("{0:0.0}", stats.waitTime);
        additionAnimation.GetComponentInChildren<TMP_Text>().text = "+" + string.Format("{0:0.0}", stats.crunchStrenght);
    }

    IEnumerator textAnimation()
    {
        additionAnimation.SetActive(true);
        float t = 0f;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y + .25f, startPosition.z);
        while(t <= 1f)
        {
            t += Time.deltaTime / animationSpeed;
            Vector3 currentPosition = Vector3.Lerp(startPosition, endPosition, t);

            additionAnimation.transform.position = currentPosition;
            yield return null;
        }
        additionAnimation.SetActive(false);
    }
}
