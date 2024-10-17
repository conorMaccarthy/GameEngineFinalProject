using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFactory : MonoBehaviour
{
    public abstract ITarget CreateTarget();
}
