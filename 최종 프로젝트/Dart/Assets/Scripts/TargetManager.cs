using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public int numberOfTargets = 4;

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
        float y = 0.8f;
        float z = Random.Range(-3f, 13.8f);
        return new Vector3(x, y, z);
    }
}
