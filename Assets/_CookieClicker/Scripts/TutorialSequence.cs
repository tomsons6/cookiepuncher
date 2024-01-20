using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSequence : MonoBehaviour
{
    [SerializeField]
    GameObject rigCanva;
    [SerializeField]
    GameObject marker;
    enum startSequence { started, showInstruction, enableMarker, finished }
    startSequence sequence;
    bool markerAnimationActive = false;

    const float startHeight = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.playerStats.IntroSequence == false)
        {
            StartCoroutine(StartSequence());
        }
        else
        {
            marker.SetActive(false);
            rigCanva.SetActive(false);
        }
    }

    IEnumerator StartSequence()
    {
        sequence = startSequence.started;
        while (sequence != startSequence.finished)
        {
            switch (sequence)
            {
                case startSequence.started:
                    rigCanva.GetComponentInChildren<TMP_Text>().text = "Another day, another cookie....";
                    yield return new WaitForSeconds(5f);
                    sequence = startSequence.showInstruction;
                    break;
                case startSequence.showInstruction:
                    rigCanva.GetComponentInChildren<TMP_Text>().text = "To earn a cookie you need to punch it, \n To punch an object you need a fist \n To make a fist press 'Grip' and 'Trigger' button";
                    yield return new WaitForSeconds(10f);
                    sequence = startSequence.enableMarker;
                    break;
                case startSequence.enableMarker:
                    rigCanva.SetActive(false);
                    marker.SetActive(true);
                    Coroutine tempRout = null;
                    if (!markerAnimationActive) 
                    {
                         tempRout = StartCoroutine(markerAnimation());
                    }
                    yield return new WaitForSeconds(10f);
                    marker.SetActive(false);
                    StopCoroutine(tempRout);
                    sequence = startSequence.finished;
                    break;
            }
            yield return null;
        }
        if(sequence == startSequence.finished)
        {
            GameManager.Instance.playerStats.IntroSequence = true;
        }
    }

    IEnumerator markerAnimation()
    {
        markerAnimationActive = true;
        Vector3 startLocation = marker.transform.localPosition;
        Vector3 endLocation = new Vector3(marker.transform.localPosition.x, marker.transform.localPosition.y + 1f, marker.transform.localPosition.z);  
        while(marker.activeInHierarchy)
        {
            float t1 = 0f;
            float t2 = 0f;
            while (t1 <= 1)
            {
                t1 += Time.deltaTime / 1.5f;
                Vector3 currentPositionUp = Vector3.Slerp(startLocation, endLocation, t1);
                marker.transform.localPosition = currentPositionUp;
                yield return null;
            }
            while(t2 <= 1)
            {
                t2 += Time.deltaTime / 1.5f;
                Vector3 CurrentPositionDonw = Vector3.Slerp(endLocation,startLocation , t2);
                marker.transform.localPosition = CurrentPositionDonw;
                yield return null;
            }
            yield return null;
        }
    }
}
