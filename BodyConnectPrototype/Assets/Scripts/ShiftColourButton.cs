using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftColourButton : MonoBehaviour
{

    public List<Button> buttons;
    public Color enabledColour;
    public Color disabledColour;

    public void SetColourOnButton(int index)
    {
        Debug.Log("Index: " + index);

        for (int i = 0; i < buttons.Count; i++)
        {
            Debug.Log("Condition: " + (index == i));
            if (index == i)
                buttons[i].image.color = enabledColour;
            else
                buttons[i].image.color = disabledColour;
        }
    }
}
