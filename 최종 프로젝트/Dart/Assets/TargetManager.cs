using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targetPrefabs; // 여러 타겟 프리팹 배열
    public int numberOfTargets = 0;

    void Start()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            Instantiate(GetRandomTargetPrefab(), GetRandomPosition(), Quaternion.identity);
        }
    }

    GameObject GetRandomTargetPrefab()
    {
        int index = Random.Range(0, targetPrefabs.Length);
        return targetPrefabs[index];
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-4.5f, 4.5f);
        float y = 0.8f; // 바닥에서 약간 위에 생성
        float z = Random.Range(-3f, 13.8f);
        return new Vector3(x, y, z);
    }
}
