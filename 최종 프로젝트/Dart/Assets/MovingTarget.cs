using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float speed = 5f; // 목표물의 이동 속도

    private Rigidbody rb;
    private bool reverseDirection = false; // 반대 방향으로 이동해야 하는지 여부를 나타내는 변수

    // 시작할 때 호출됩니다.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 프레임마다 호출됩니다.
    private void Update()
    {
        MoveTarget();
    }

    // 목표물을 이동시키는 함수
    private void MoveTarget()
    {
        // 목표물을 좌우로 이동시킵니다.
        Vector3 movement = new Vector3(speed, 0f, 0f);
        rb.velocity = movement;

        // 충돌을 감지하여 반대 방향으로 이동해야 하는지 확인합니다.
        if (reverseDirection)
        {
            speed *= -1; // 이동 속도를 반대로 바꿉니다.
            reverseDirection = false; // 반대 방향으로 이동 완료
        }
    }

    // 충돌이 시작할 때 호출됩니다.
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 벽인지 확인합니다.
        if (collision.gameObject.CompareTag("Wall"))
        {
            reverseDirection = true; // 반대 방향으로 이동해야 함
        }
    }
}
