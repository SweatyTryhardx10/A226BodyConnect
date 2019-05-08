using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Group 
{
    public string groupName;
    public int groupMemberAmount;
    public string groupDescription;
    public List<Session> sessions = new List<Session>();

    public Group(string name, string description)
    {
        groupName = name;
        groupDescription = description;
    }
}
