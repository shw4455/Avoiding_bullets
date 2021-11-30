using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; //최고 기록을 표시할 텍스트 컴포넌트, 여기서 컴포넌트라고 하는 이유 정말로 컴포넌트로 들어가 있어서이다 -.-

    private float surviveTime; // 생존시간
    private bool isGameover; // 게임오버 상태
    void Start()
    {   // 생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover) // isGameover가 false인 동안
        {
            surviveTime += Time.deltaTime; //생존 시간을 갱신
            timeText.text = "Time : " + string.Format("{0:F2}", surviveTime); //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시 => ++ 소수점 둘째자리까지 출력
        } // isGameover가 false인 동안 생존시간을 표시하는 함수 = 게임오버가 아닌 동안

        else 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene"); // SampleScene 로드
            }
        } // 게임 오버인 상태에서 R 키를 누른 경우
    }

    public void EndGame()
    {
        isGameover = true; // 현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime"); // 값이 없으면 0을 반환

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime; // 최고 기록 값을 현재 생존 시간 값으로 변경
            PlayerPrefs.SetFloat("BestTime", surviveTime); // 변경된 최고 기록을 BestTime으로 키로 저장
        }
        recordText.text = "Best Time : " + string.Format("{0:F2}", bestTime); // 최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
    }
}
