using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ParticleRotationConstraint : MonoBehaviour
{
    private RotationConstraint constraint;
    private Transform sourceTransform;

    void Start()
    {
        constraint = GetComponent<RotationConstraint>();
        sourceTransform = GameObject.Find("ObjectPool").transform;

        ConstraintSource source = new ConstraintSource
        {
            sourceTransform = sourceTransform,
            weight = 1f
        };

        constraint.AddSource(source);
    }
}
