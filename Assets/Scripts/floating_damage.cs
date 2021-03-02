using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }
}
