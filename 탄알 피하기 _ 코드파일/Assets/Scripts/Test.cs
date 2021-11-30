using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float a = 1234.5678f;

    
    void Start()
    {
        Debug.Log(a);
        Debug.Log("123");

        string temp = string.Format("{0:F2}", a);
        Debug.Log(temp);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
