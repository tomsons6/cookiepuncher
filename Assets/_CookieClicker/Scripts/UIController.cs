using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text cookieCount;
    public TMP_Text strenght;
    public List<GameObject> panels;

    private void Start()
    {
        UpdateText();
        GameManager.Instance.objectWasPunched += UpdateText;
    }
    public void UpdateText()
    {
        cookieCount.text = "Coockies crunched - " + string.Format("{0:0.0}", GameManager.Instance.playerStats.cookieCount);
        strenght.text = "Current strenght - " + string.Format("{0:0.0}", GameManager.Instance.playerStats.punchStrenght);
    }
    public void SwitchPanel(GameObject panelToOpen)
    {
        foreach (GameObject panel in panels)
        {
            if(panel != panelToOpen)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }

        }
    }
}
