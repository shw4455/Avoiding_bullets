using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start()
    {   
        bulletRigidbody = GetComponent<Rigidbody>(); // 리지드바디 변수를 만들어, 오브젝트가 생성되었을때, 오브젝트의 리지드바디 컴포넌트를 받아온다
        bulletRigidbody.velocity = transform.forward * speed; // 총알의 현재 속도값 = 오브젝트의 z축 방향성 * 속도

        // transform.forward 실험용 코드
        // Debug.Log(bulletRigidbody.velocity);

        Destroy(gameObject, 3f); //오브젝트는 생성된 후 3초 뒤 파괴된다
    }
    private void OnTriggerEnter(Collider other)  //트리거 충돌시 자동으로 실행되는 메서드
    {
        if (other.tag == "Player") //충돌한 오브젝트가 Player 태그를 가진 경우
        {
            PlayerController playerController = other.GetComponent<PlayerController>();  // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            if (playerController != null)  // 상대방으로부터 Playercontroller 컴포넌트를 가져오는데 성공했다면
            {
                // 상대방 PlayerCOntroller 컴포넌트의 Die() 메서드를 실행 
                playerController.Die();
            }
        }
    }
}
