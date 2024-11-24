using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeTargetFactory : TargetFactory
{
    public TargetLarge targetPrefab;
    
    public override ITarget CreateTarget()
    {
        TargetLarge newTarget = GameObject.Instantiate(targetPrefab, new Vector3(Random.Range(-8, 9), 1.5f, 30), Quaternion.identity);
        return newTarget;
    }
}
