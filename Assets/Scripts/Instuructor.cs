using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instuructor : MonoBehaviour
{
    [SerializeField]
    GameObject instructorPanel;

    [SerializeField]
    GameObject textPanel;

    [SerializeField]
    GameObject textPanel2;

    [SerializeField]
    GameObject textPanel3;

    int counter_instructorPanel;
    int counter_textPanel;

    private void Awake()
    {
        instructorPanel.gameObject.SetActive(false);
        textPanel.gameObject.SetActive(true);
        textPanel2.gameObject.SetActive(false);
        textPanel3.gameObject.SetActive(false);
    }

    public void ShowBtn()
    {
        counter_instructorPanel++;
        if(counter_instructorPanel % 2 == 1)
        {
            instructorPanel.gameObject.SetActive(true);
        }
    }
    public void BackBtn()
    {
        counter_instructorPanel++;
        if (counter_instructorPanel % 2 == 0)
        {
            instructorPanel.gameObject.SetActive(false);
        }
    }

    public void RightClick()
    {
        counter_textPanel++;
        if(counter_textPanel % 3 == 1)
        {
            textPanel.gameObject.SetActive(false);
            textPanel2.gameObject.SetActive(true);
            textPanel3.gameObject.SetActive(false);
        }
        else if (counter_textPanel % 3 == 2)
        {
            textPanel.gameObject.SetActive(false);
            textPanel2.gameObject.SetActive(false);
            textPanel3.gameObject.SetActive(true);
        }
        else
        {
            textPanel.gameObject.SetActive(true);
            textPanel2.gameObject.SetActive(false);
            textPanel3.gameObject.SetActive(false);
        }
    }
}
