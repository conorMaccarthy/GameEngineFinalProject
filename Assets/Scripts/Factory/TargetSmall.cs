using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSmall : MonoBehaviour, ITarget
{
    public void Move()
    {
        StartCoroutine(MoveTarget());
    }

    private IEnumerator MoveTarget()
    {
        Vector3 startPosition = transform.position;
        Vector3 endposition = DetermineEndPosition(transform.position.x, transform.position.y, transform.position.z);

        float timeElapsed = 0;
        float travelTime = 1.5f;

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

    private Vector3 DetermineEndPosition(float xPosition, float yPosition, float zPosition)
    {
        float finalPositionX;
        float finalPositionY;

        if (xPosition < 0) finalPositionX = xPosition + 12;
        else finalPositionX = xPosition - 12;

        if (yPosition < 3) finalPositionY = yPosition + 3;
        else finalPositionY = yPosition - 3;

        return new Vector3(finalPositionX, finalPositionY, zPosition - 15);
    }
}
