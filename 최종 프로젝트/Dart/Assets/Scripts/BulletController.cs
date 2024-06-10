using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Target"))
        {
            if (collision.gameObject != null)
            {
                Vector3 targetPosition = collision.gameObject.transform.position;
                Quaternion targetRotation = collision.gameObject.transform.rotation;

                TargetRespawner respawner = FindObjectOfType<TargetRespawner>();
                if (respawner != null)
                {
                    respawner.RespawnTarget(targetPosition, targetRotation);
                }

                ScoreManager.instance.AddScore(1);

                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
