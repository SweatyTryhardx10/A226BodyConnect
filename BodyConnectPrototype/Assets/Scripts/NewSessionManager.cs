using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSessionManager : MonoBehaviour
{
    public Slider dayInput;
    public Slider hourInput;
    public Slider minuteInput;
    public Slider durationInput;
    public SessionManager sessionManager;
    public PageManager pageManager;

    public void CreateSession()
    {
        sessionManager.AddSession(dayInput.value, hourInput.value, minuteInput.value, durationInput.value);
        pageManager.ChangePage(3);
    }

   
}
