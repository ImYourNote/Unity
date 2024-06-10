using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRespawner : MonoBehaviour
{
    public GameObject[] targetPrefabs;

    public void RespawnTarget(Vector3 position, Quaternion rotation)
    {
        StartCoroutine(RespawnCoroutine(position, rotation));
    }

    private IEnumerator RespawnCoroutine(Vector3 position, Quaternion rotation)
    {
        yield return new WaitForSeconds(3);

        if (targetPrefabs != null && targetPrefabs.Length > 0)
        {
            GameObject targetPrefab = GetRandomTargetPrefab();
            Instantiate(targetPrefab, position, rotation);
        }
    }

    GameObject GetRandomTargetPrefab()
    {
        int index = Random.Range(0, targetPrefabs.Length);
        return targetPrefabs[index];
    }
}
