using BNG;
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
    SmoothLocomotion locomotion;

    const float startHeight = 0;
    private bool areInfoTextRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.playerStats.IntroSequence == false)
        {
            StartCoroutine(StartSequence());
            locomotion = rigCanva.GetComponentInParent<SmoothLocomotion>();
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
                    //rigCanva.GetComponentInChildren<TMP_Text>().text = "To earn a cookie you need to punch it, \n To punch an object you need a fist \n To make a fist press 'Grip' and 'Trigger' button";                   
                    //yield return new WaitForSeconds(10f);
                    StartCoroutine(InstructionTexts(rigCanva.GetComponentInChildren<TMP_Text>()));
                    while(areInfoTextRunning)
                    {
                        yield return null;
                    }
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
    IEnumerator InstructionTexts(TMP_Text text)
    {
        areInfoTextRunning = true;
        locomotion.enabled = false;
        text.text = "To earn a cookie you need to punch it, \n To punch an object you need a fist \n To make a fist press 'Grip' and 'Trigger' button";
        yield return new WaitForSeconds(10f);
        text.text = "To move around use left hands joystick";
        locomotion.enabled = true;
        yield return new WaitForSeconds(5f);
        text.text = "";
        areInfoTextRunning = false;

    }
}
