using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GroupButton : MonoBehaviour
{
    public Text groupName;
    public Text groupNumber;

    private GroupManager groupManager;
    private int groupIndex;

    public void SetGroupNumber(GroupManager manager, int index) {
        groupManager = manager;
        groupIndex = index;

        GetComponent<Button>().onClick.AddListener(() => groupManager.SetGroupInSessionManager(groupIndex));
        GetComponent<Button>().onClick.AddListener(() => TopBar.instance.SetHeaderText(groupName.text));
    }
}
