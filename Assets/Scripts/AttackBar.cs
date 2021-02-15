using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBar : MonoBehaviour
{
    public Slider slider;

    public void SetAttackCooldown(float coolDown)
    {
        slider.maxValue = coolDown;
        slider.value = coolDown;
    }
    public void SetTime(float time)
    {
        slider.value = time;
    }
}
