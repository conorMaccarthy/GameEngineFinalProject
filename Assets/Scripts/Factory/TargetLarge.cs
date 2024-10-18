using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLarge : MonoBehaviour, ITarget
{
    public void Move()
    {
        StartCoroutine(MoveTarget());
    }

    private IEnumerator MoveTarget()
    {
        Vector3 startPosition = transform.position;
        Vector3 endposition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 15);
        float timeElapsed = 0;
        float travelTime = 2.5f;

        yield return new WaitForSeconds(0.5f);

        while (timeElapsed < travelTime)
        {
            transform.position = Vector3.Lerp(startPosition, endposition, timeElapsed / travelTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
    }
}
