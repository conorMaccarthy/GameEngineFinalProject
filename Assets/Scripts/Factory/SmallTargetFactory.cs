using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTargetFactory : TargetFactory
{
    public TargetSmall targetPrefab;

    public override ITarget CreateTarget()
    {
        TargetSmall newTarget = GameObject.Instantiate(targetPrefab, new Vector3(Random.Range(-8, 8), 1.5f, 30), Quaternion.identity);
        return newTarget;
    }
}
