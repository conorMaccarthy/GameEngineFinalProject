using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public List<TargetFactory> targetFactoriesList;
    private TargetFactory targetFactory;

    private void Start()
    {
        InvokeRepeating("SpawnRandomTarget", 1, 6);
    }

    private void SpawnRandomTarget()
    {
        targetFactory = targetFactoriesList[Random.Range(0, targetFactoriesList.Count)];

        ITarget target = targetFactory.CreateTarget();
        target.Move();
    }
}
