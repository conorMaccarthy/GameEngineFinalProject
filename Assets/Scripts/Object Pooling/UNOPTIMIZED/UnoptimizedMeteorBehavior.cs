using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoptimizedMeteorBehavior : MonoBehaviour
{
    public void BeginMoving()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(transform.position.x + 500, transform.position.y - 20, transform.position.z + 50);

        float timeElapsed = 0;
        float travelTime = 16;

        while (timeElapsed < travelTime)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / travelTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Deactivate();
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
