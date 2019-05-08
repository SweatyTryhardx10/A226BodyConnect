using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalenderButton : MonoBehaviour
{
    public Text sessionDay;
    public Text sessionDate;
    public Text sessionTime;

    private SessionManager sessionManager;
    private int sessionIndex;

    //public void SetSessionNumber(SessionManager manager, int index)
    //{
    //    sessionManager = manager;
    //    sessionIndex = index;

    //    GetComponent<Button>().onClick.AddListener(() => sessionManager.SetGroupInSessionManager(sessionIndex));
    //}

}
