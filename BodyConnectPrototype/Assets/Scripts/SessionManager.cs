using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public Group chosenGroup;
    public GameObject sessionButton;
    public Transform sessionPagePanel;
    public Vector3 startPosition;
    public float horizontalSpacing = 0f;
    public float verticalSpacing = 250f;

    public void SetGroup(Group group)
    {
        chosenGroup = group;

        float yPos = 0;
        for (int i = 0; i < chosenGroup.sessions.Count; i++)
        {

            GameObject sessionObject = Instantiate(sessionButton, sessionPagePanel);
            sessionObject.GetComponent<CalenderButton>().sessionDay.text = chosenGroup.sessions[i].dayName;
            sessionObject.GetComponent<CalenderButton>().sessionDate.text = chosenGroup.sessions[i].day + "/" + chosenGroup.sessions[i].month;
            sessionObject.GetComponent<CalenderButton>().sessionTime.text = chosenGroup.sessions[i].hour + ":" + chosenGroup.sessions[i].minutes;

            sessionObject.transform.position = startPosition + new Vector3((i+2) % 2 * horizontalSpacing, yPos);

            if ((i+1) % 2 == 0 && i != 0)
                yPos += verticalSpacing;
        }
    }
}
