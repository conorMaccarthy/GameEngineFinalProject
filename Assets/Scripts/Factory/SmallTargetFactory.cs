using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTargetFactory : TargetFactory
{
    public TargetSmall targetPrefab;

    private float[] validSpawnPositionsX = { -8, -7, -6, -5, 5, 6, 7, 8 };
    private float[] validSpawnPositionsY = { 1.5f, 4.5f };

    public override ITarget CreateTarget()
    {
        TargetSmall newTarget = GameObject.Instantiate(targetPrefab, new Vector3(validSpawnPositionsX[Random.Range(0, 8)], validSpawnPositionsY[Random.Range(0, 2)], 30), Quaternion.identity);
        return newTarget;
    }
}
