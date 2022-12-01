using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaySelection : MonoBehaviour
{
    private int importantMonth = 12;
    public GameObject[] dayObjects;
    public string[] dayNames;
    public GameObject dayLabel;
    public GameObject nameLabel;
    private int dayDisplay;

    public bool DebugMode;


    // Start is called before the first frame update
    void Start()
    {
        dayDisplay = Mathf.Min(System.DateTime.Now.Day, dayNames.Length);
        if (System.DateTime.Now.Month == importantMonth || DebugMode)
        {
            dayObjects[dayDisplay-1].SetActive(true);
            dayLabel.GetComponent<TextMeshProUGUI>().text = dayDisplay.ToString();
            nameLabel.GetComponent<TextMeshProUGUI>().text = dayNames[dayDisplay-1];
        }
        else
        {
            dayLabel.GetComponent<TextMeshProUGUI>().text = "Komm zurueck im";
            nameLabel.GetComponent<TextMeshProUGUI>().text = "Dezember!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!DebugMode && Input.GetTouch(0).phase == TouchPhase.Ended && System.DateTime.Now.Month == importantMonth)
        {
            dayObjects[dayDisplay - 1].SetActive(false);
            if (dayDisplay>1)
            {
                dayDisplay--;
            }
            else
            {
                dayDisplay = Mathf.Min(System.DateTime.Now.Day, dayNames.Length);
            }
            dayObjects[dayDisplay - 1].SetActive(true);
            dayLabel.GetComponent<TextMeshProUGUI>().text = dayDisplay.ToString();
            nameLabel.GetComponent<TextMeshProUGUI>().text = dayNames[dayDisplay - 1];
        }
        if (DebugMode && Input.GetMouseButtonDown(0))
        {
            dayObjects[dayDisplay - 1].SetActive(false);
            if (dayDisplay > 1)
            {
                dayDisplay--;
            }
            else
            {
                dayDisplay = Mathf.Min(System.DateTime.Now.Day, dayNames.Length);
            }
            dayObjects[dayDisplay - 1].SetActive(true);
            dayLabel.GetComponent<TextMeshProUGUI>().text = dayDisplay.ToString();
            nameLabel.GetComponent<TextMeshProUGUI>().text = dayNames[dayDisplay - 1];
        }
    }
}
