using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
   public Text textComponent;
   public void ChangeValue(float value)
    {
        textComponent.text = value.ToString();
    }
}
