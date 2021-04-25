using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_after_sec : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }
}
