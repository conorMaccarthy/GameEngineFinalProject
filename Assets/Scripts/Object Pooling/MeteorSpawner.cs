using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, 1.2f);
    }

    private void SpawnMeteor()
    {
        GameObject newMeteor = objectPool.GetObjectFromPool().gameObject;

        newMeteor.SetActive(true);
        newMeteor.transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y, transform.position.y + 30), Random.Range(transform.position.z, transform.position.z + 70));
        newMeteor.GetComponent<MeteorBehavior>().BeginMoving();
    }
}
