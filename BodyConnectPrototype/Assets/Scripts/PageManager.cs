using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public Transform[] panels;
    public TopBar topBar;
    public GameObject menuPanel;

    [Header("Animator References")]
    public Animator menuAnimator;
    public List<Animator> pageAnimators;

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

    public void ShowMenu(bool show)
    {
        menuAnimator.SetBool("Show", show);
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

        AnimatePages(number);
    }
    public void ChangePage(int number)
    {
        pageStack.Add(number);

        AnimatePages(number);
    }

    private void AnimatePages(int number)
    {
        for (int i = 0; i < pageAnimators.Count; i++)
        {
            if (i == number)
            {
                pageAnimators[i].SetBool("Show", true);
            }
            else
            {
                pageAnimators[i].SetBool("Show", false);
            }
        }
    }
}
