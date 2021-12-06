using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        //수작업(드래그&드롭)으로 하는 작업을 없애기 위한 코드
        playerRigidbody = GetComponent<Rigidbody>();   
    }
    
    void Update()
    {
        // 수평축과 수직축의 입력값을 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 이동속도를 입력값과 속도(수정가능)을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 객체를 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 생성한 객체를 리지드바디 속성에 할당
        playerRigidbody.velocity = newVelocity;

        //// 상하좌우 방향키를 감지하고, 그 힘을 가하는 함수 // 관성 있음
        //if (Input.GetKey(KeyCode.UpArrow) == true ) playerRigidbody.AddForce(0f, 0f, speed);
        //if (Input.GetKey(KeyCode.DownArrow) == true) playerRigidbody.AddForce(0f, 0f, -speed);
        //if (Input.GetKey(KeyCode.RightArrow) == true) playerRigidbody.AddForce(speed, 0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow) == true) playerRigidbody.AddForce(-speed, 0f, 0f);
    }
    public void Die()
    {   // 자기 자신을 가리키고, 오브젝트를 비활성화하는 함수
        gameObject.SetActive(false);
       
        GameManager gameManager = FindObjectOfType<GameManager>(); // 씬에 존재하는 GameManger 타입의 오브젝트를 찾아서 가져오기
        gameManager.EndGame(); // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행

        /*  gameobject는 GameOjbect클래스로 만들어진 변수이며
        *   자신을 가리키는 변수이다
        *   SetActive는 GameObject에 오브젝트의 활성화/비활성화를 설정하는 메서드이다
        */
    }
}
