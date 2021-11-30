using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹
    public float spwanRateMin = 2.5f; // 촤소 생성 주기
    public float spwanRateMax = 3f; // 최대 생성 주기

    private Transform target; //발사할 대상
    private float spwanRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 지점에서 지난 시간

    void Start()
    {
        timeAfterSpawn = 0f; // 최근 생성 이후의 누적 시간을  0으로 초기화
        spwanRate = Random.Range(spwanRateMin, spwanRateMax); // 탄알 생성 간격을 spwanRateMin, spwanRateMax 사이로 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform; // PlayerComtroller 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 지정
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime; // timeAfterSpawn 갱신

        if (timeAfterSpawn >= spwanRate)
        {
            timeAfterSpawn = 0; // 누적된 시간을 리셋

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //bullet의 복제본을 생성, transform.position, transform.rotation 위치에 생성

            bullet.transform.LookAt(target); // bullet의 방향이 target을 향하도록 회전

            spwanRate = Random.Range(spwanRateMin, spwanRateMax); // 다음번 생성 간격을 spwanRateMin, spwanRateMax 사이에 랜덤 지정
        }
    }
}
// 생성 주기도 public으로 바꿔서 수정 가능하게 해도 되지 않은지 => 생성주기를 public spwanRateMin, spwanRateMax을 통해 조절할 수 있기 때문에 spwanRateMin, spwanRateMax을 사용한 결과값인 spwanRate는 private여도 괜찮다