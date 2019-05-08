using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public Transform[] panels;
    public TopBar topBar;
    private List<int> pageStack = new List<int>();

    public void Start()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].gameObject.SetActive(true);
        }
        ChangePage(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePage(pageStack[pageStack.Count - 2], false);
            pageStack.RemoveAt(pageStack.Count - 1);
        }
    }

    public void ChangePage(int number, bool isForward = true)
    {
        if (isForward)
        {
            pageStack.Add(number);
        }

        if (number == 2)
        {
            topBar.SetHeaderText("Groups");
        }

        for (int i = 0; i < panels.Length; i++)
        {
            if (i == number)
            {
                panels[i].gameObject.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            }
            else
            {
                panels[i].gameObject.transform.position = new Vector3(10000, 0, 0);
            }
        }
    }
    public void ChangePage(int number)
    {
        pageStack.Add(number);

        for (int i = 0; i < panels.Length; i++)
        {
            if (i == number)
            {
                panels[i].gameObject.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            }
            else
            {
                panels[i].gameObject.transform.position = new Vector3(10000, 0, 0);
            }
        }
    }
}
