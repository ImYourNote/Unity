using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float speed = 5f; // ��ǥ���� �̵� �ӵ�

    private Rigidbody rb;
    private bool reverseDirection = false; // �ݴ� �������� �̵��ؾ� �ϴ��� ���θ� ��Ÿ���� ����

    // ������ �� ȣ��˴ϴ�.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // �����Ӹ��� ȣ��˴ϴ�.
    private void Update()
    {
        MoveTarget();
    }

    // ��ǥ���� �̵���Ű�� �Լ�
    private void MoveTarget()
    {
        // ��ǥ���� �¿�� �̵���ŵ�ϴ�.
        Vector3 movement = new Vector3(speed, 0f, 0f);
        rb.velocity = movement;

        // �浹�� �����Ͽ� �ݴ� �������� �̵��ؾ� �ϴ��� Ȯ���մϴ�.
        if (reverseDirection)
        {
            speed *= -1; // �̵� �ӵ��� �ݴ�� �ٲߴϴ�.
            reverseDirection = false; // �ݴ� �������� �̵� �Ϸ�
        }
    }

    // �浹�� ������ �� ȣ��˴ϴ�.
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ������ Ȯ���մϴ�.
        if (collision.gameObject.CompareTag("Wall"))
        {
            reverseDirection = true; // �ݴ� �������� �̵��ؾ� ��
        }
    }
}
