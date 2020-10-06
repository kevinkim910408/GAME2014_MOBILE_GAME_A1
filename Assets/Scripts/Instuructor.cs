using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: Instructor.cs
/// Date last Modified: 2020-10-07
/// Program description
///  - vision Instructor panel
///  
/// Revision History
/// 2020-09-23: add Internal Documentation
/// 2020-10-07: inline comments, make code looks clear, removed unnecessary codes
/// </summary>
public class Instuructor : MonoBehaviour
{
    #region Variables

    // Get Instructor Panel
    [SerializeField]
    GameObject instructorPanel;

    // Get Text Panels for the Instructor - total 3 pages
    [SerializeField]
    GameObject textPanel;
    [SerializeField]
    GameObject textPanel2;
    [SerializeField]
    GameObject textPanel3;

    // For toggle the Instructor Panel and Text Panels
    int counter_instructorPanel;
    int counter_textPanel;

    #endregion

    #region Unity_Method
    private void Awake()
    {
        // If User Click the Instructor Button, Only Set Active the text in the first page.
        instructorPanel.gameObject.SetActive(false);
        textPanel.gameObject.SetActive(true);
        textPanel2.gameObject.SetActive(false);
        textPanel3.gameObject.SetActive(false);
    }

    #endregion

    #region Custom_Method
    // toggle Instructor button
    public void ShowBtn()
    {
        counter_instructorPanel++;
        if(counter_instructorPanel % 2 == 1)
        {
            instructorPanel.gameObject.SetActive(true);
        }
    }

    // Back button in the instructor
    public void BackBtn()
    {
        counter_instructorPanel++;
        if (counter_instructorPanel % 2 == 0)
        {
            instructorPanel.gameObject.SetActive(false);
        }
    }

    // Next Page Button
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
    #endregion
}
