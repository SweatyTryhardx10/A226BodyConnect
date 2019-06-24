using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour
{
    public Group chosenGroup;
    public GameObject sessionButton;
    public Transform sessionPagePanel;
    public Vector3 startPosition;
    public float horizontalSpacing = 0f;
    public float verticalSpacing = 250f;
    public Slider dayValue;
    public Slider hourValue;
    public Slider minuteValue;
    public Slider durationValue;
    public GroupManager groupManager;
    public Text informationalText;

    private List<GameObject> sessionButtons;

    private void Awake()
    {
        sessionButtons = new List<GameObject>();
    }

    public void SetGroup(Group group)
    {
        chosenGroup = group;

        // Delete all current session buttons
        for (int i = 0; i < sessionButtons.Count; i++)
        {
            Destroy(sessionButtons[i]);
        }

        // Create all sessions buttons
        for (int i = 0; i < chosenGroup.sessions.Count; i++)
        {
            CreateSessionButton(i);
        }

        if (chosenGroup.sessions.Count <= 0)
            informationalText.gameObject.SetActive(true);
        else
            informationalText.gameObject.SetActive(false);
    }
    public void AddSession(float dayValue, float hourValue, float minuteValue, float durationValue)
    {
        // Loops through the group manager's group list and finds the chosen group by comparing group names
        int groupIndex = 0;
        for (int i = 0; i < groupManager.groupList.Count; i++)
        {
            if (groupManager.groupList[i].groupName == chosenGroup.groupName)
                groupIndex = i;
        }

        groupManager.groupList[groupIndex].sessions.Add(new Session(dayValue, hourValue, minuteValue, durationValue));
        CreateSessionButton(chosenGroup.sessions.Count - 1);

    }
    public void CreateSessionButton(int index)
    {
        GameObject sessionObject = Instantiate(sessionButton, sessionPagePanel);
        sessionObject.GetComponent<CalenderButton>().sessionDay.text = chosenGroup.sessions[index].dayName;
        sessionObject.GetComponent<CalenderButton>().sessionDate.text = chosenGroup.sessions[index].day + "/" + chosenGroup.sessions[index].month;
        sessionObject.GetComponent<CalenderButton>().sessionTime.text = chosenGroup.sessions[index].hour + ":" + chosenGroup.sessions[index].minutes;

        // Loops through the group manager's group list and finds the chosen group by comparing group names
        int groupIndex = 0;
        for (int i = 0; i < groupManager.groupList.Count; i++)
        {
            if (groupManager.groupList[i].groupName == chosenGroup.groupName)
                groupIndex = i;
        }

        int sessionIndex = groupManager.groupList[groupIndex].sessions.Count - 1;
        groupManager.SetNewSessionNotification(groupIndex, sessionIndex);

        sessionButtons.Add(sessionObject);

        informationalText.gameObject.SetActive(false);
    }
}
