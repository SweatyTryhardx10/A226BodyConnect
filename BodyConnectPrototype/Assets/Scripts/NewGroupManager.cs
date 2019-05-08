using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGroupManager : MonoBehaviour
{
    public InputField nameInput;
    public InputField descriptionInput;
    public GroupManager groupManager;
    public PageManager pageManager;

    public void CreateGroup()
    {
        groupManager.AddGroup(nameInput.text, descriptionInput.text);
        pageManager.ChangePage(2);
        groupManager.AddGroupButton(nameInput.text, "1");
    }
}
