using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_boss_control : MonoBehaviour
{
    public GameObject endGameCanvas;

    private void OnDestroy()
    {
        endGameCanvas.SetActive(true);
    }

}
