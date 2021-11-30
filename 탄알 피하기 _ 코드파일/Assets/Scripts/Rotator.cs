using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    } // 1초 동안 회전하는 각도를 지정, TIme.deltaTIme을 이용해 역수를 곱해줬기에 컴퓨터 성능이 달라도 같은 효과를 낸다
}
