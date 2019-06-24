using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleAndroidNotifications;
using System;

[System.Serializable]
public class Session
{
    public string dayName;
    public int day;
    public int month;
    public int hour;
    public int minutes;

    public bool notificationSet = false;

    public Session(float dayNumber, float hourNumber, float minuteNumber, float durationNumber)
    {
        day = (int)dayNumber;
        month = 5;
        hour = (int)hourNumber;
        minutes = (int)minuteNumber;
    }

    public void PlanNotification(string groupName)
    {
        if (notificationSet)
            return;

        int morningHour = 7;
        int morningMinutes = 0;

        int sessionDay = day;
        int sessionHour = hour;
        int sessionMinutes = minutes;

        int systemDay = System.DateTime.Now.Day;
        int systemHour = System.DateTime.Now.Hour;
        int systemMinutes = System.DateTime.Now.Minute;
        int systemSeconds = System.DateTime.Now.Second;

        // Morning notification
        long delayTime = (sessionDay * 86400 + morningHour * 3600 + morningMinutes * 60) - (systemDay * 86400 + systemHour * 3600 + systemMinutes * 60) - systemSeconds;    // Session time - system time

        if (delayTime > 0f)
            NotificationManager.Send(TimeSpan.FromSeconds(delayTime), groupName + " | " + "MEH", "Make sure to attend!", new Color(0f, 0.7f, 0f));


        Debug.Log("New Notification set to trigger in " + delayTime);

        // Notification right before session time
        int forwardTime = 60 * 60;   // The amount of time that the notification is set in advance of the session's planned time
        delayTime = (sessionDay * 86400 + sessionHour * 3600 + sessionMinutes * 60) - (systemDay * 86400 + systemHour * 3600 + systemMinutes * 60) - systemSeconds - forwardTime;    // Session time - system time
        NotificationManager.Send(TimeSpan.FromSeconds(delayTime), groupName + " | " + "Session", "Your workout is in 1 hour!", new Color(0f, 0.7f, 0f));

        notificationSet = true;

        Debug.Log("New Notification set to trigger in " + delayTime);
    }
}
