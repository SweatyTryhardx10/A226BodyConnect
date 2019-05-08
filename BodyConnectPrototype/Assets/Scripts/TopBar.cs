using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour
{
    public static TopBar instance;

    public Text header;

    public void Awake()
    {
        instance = this;
    }

    public void SetHeaderText(string groupName)
    {
        header.text = groupName;
    }
}
