using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
            Debug.Log("플레이어가 임의의 키를 누름");
        if (Input.anyKey)
            Debug.Log("플레이어가 임의의 키를 계속 누른 상태임");

        // 키보드 입력
        if (Input.GetKeyDown(KeyCode.Return))
            Debug.Log("아이템을 구입");
        if (Input.GetKey(KeyCode.LeftArrow))
            Debug.Log("왼쪽이동 시작");
        if (Input.GetKeyUp(KeyCode.RightArrow))
            Debug.Log("오른쪽 이동 중지");

        // 마우스입력
        if (Input.GetMouseButtonDown(0))
            Debug.Log("미사일 발사");
        if (Input.GetMouseButton(0))
            Debug.Log("미사일 모으기");
        if (Input.GetMouseButtonUp(0))
            Debug.Log("슈퍼 미사일 발사");
    }
}

