using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;
using System;

public class GroupManager : MonoBehaviour
{
    public List<Group> groupList;
    public GameObject groupButton;
    public Transform groupsPagePanel;
    public float spacing = 50;
    public Vector3 startPosition;
    public PageManager pageManager;
    public SessionManager sessionManager;
    private int amountGroupButton;

    public void Start()
    {
        for (int i = 0; i < groupList.Count; i++)
        {
            AddGroupButton(groupList[i].groupName, groupList[i].groupMemberAmount.ToString());
        }

        NotificationManager.Send(TimeSpan.FromSeconds(5), "Simple notification", "Customize icon and color", new Color(1, 0.3f, 0.15f));

    }

    public void SetGroupInSessionManager(int groupIndex)
    {
        Debug.Log("Group Index: " + groupIndex);
        sessionManager.SetGroup(groupList[groupIndex]);
    }
    public void AddGroup(string name, string description)
    {
        groupList.Add(new Group(name, description));
    }
    public void AddGroupButton(string name, string memberAmount)
    {
        amountGroupButton++;

        GameObject groupObject = Instantiate(groupButton, groupsPagePanel);
        groupObject.GetComponent<GroupButton>().groupName.text = name;
        groupObject.GetComponent<GroupButton>().groupNumber.text = memberAmount;
        groupObject.GetComponent<Button>().onClick.AddListener(() => pageManager.ChangePage(3));

        int groupNumber = amountGroupButton - 1;

        groupObject.GetComponent<GroupButton>().SetGroupNumber(this, groupNumber);
    }
}
