using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public List<TargetFactory> targetFactoriesList;
    private TargetFactory targetFactory;

    private int targetsSpawned;

    private void Awake()
    {
        targetsSpawned = 0;
    }

    public void StartSpawning(int diff)
    {
        UIManager.instance.ResetScore();
        StopSpawning();
        targetsSpawned = 0;

        switch (diff)
        {
            case 0:
                InvokeRepeating("SpawnLargeTarget", 0.5f, 4.5f);
                break;
            case 1:
                InvokeRepeating("SpawnMediumTarget", 0.5f, 4.5f);
                break;
            case 2:
                InvokeRepeating("SpawnSmallTarget", 0.5f, 4.5f);
                break;
            case 3:
                InvokeRepeating("SpawnRandomTarget", 0.5f, 4.5f);
                break;
        }
    }

    public void StopSpawning()
    {
        CancelInvoke();
        Destroy(GameObject.FindGameObjectWithTag("Target"));
    }

    private void SpawnRandomTarget()
    {
        targetFactory = targetFactoriesList[Random.Range(0, targetFactoriesList.Count)];

        ITarget target = targetFactory.CreateTarget();
        target.Move();

        targetsSpawned++;
        if (targetsSpawned >= 5) StopSpawning();
    }

    private void SpawnSmallTarget()
    {
        targetFactory = targetFactoriesList[0];

        ITarget target = targetFactory.CreateTarget();
        target.Move();

        targetsSpawned++;
        if (targetsSpawned >= 5) StopSpawning();
    }

    private void SpawnMediumTarget()
    {
        targetFactory = targetFactoriesList[1];

        ITarget target = targetFactory.CreateTarget();
        target.Move();

        targetsSpawned++;
        if (targetsSpawned >= 5) StopSpawning();
    }

    private void SpawnLargeTarget()
    {
        targetFactory = targetFactoriesList[2];

        ITarget target = targetFactory.CreateTarget();
        target.Move();

        targetsSpawned++;
        if (targetsSpawned >= 5) StopSpawning();
    }
}
