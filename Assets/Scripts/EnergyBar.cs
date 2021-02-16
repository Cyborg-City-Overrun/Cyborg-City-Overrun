using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxEnergy(float coolDown)
    {
        slider.maxValue = coolDown;
        slider.value = coolDown;
    }
    public void SetEnergy(float time)
    {
        slider.value = time;
    }
}
