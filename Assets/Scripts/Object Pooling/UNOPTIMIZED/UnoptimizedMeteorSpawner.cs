using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoptimizedMeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, 0.1f);
    }

    private void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab);

        newMeteor.transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y, transform.position.y + 30), Random.Range(transform.position.z, transform.position.z + 70));
        newMeteor.GetComponent<UnoptimizedMeteorBehavior>().BeginMoving();
    }
}
