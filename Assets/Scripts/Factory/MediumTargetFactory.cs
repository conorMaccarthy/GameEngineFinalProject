using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumTargetFactory : TargetFactory
{
    public TargetMedium targetPrefab;

    private float[] validSpawnPositionsX = { -8, -7, -6, -5, 5, 6, 7, 8 };

    public override ITarget CreateTarget()
    {
        TargetMedium newTarget = GameObject.Instantiate(targetPrefab, new Vector3(validSpawnPositionsX[Random.Range(0, 8)], 1.5f, 30), Quaternion.identity);
        return newTarget;
    }
}
