using UnityEngine;
using System.Collections;

public class PusherController : MonoBehaviour
{
    public float moveDistance = 1.75f;
    public float moveSpeed = 1f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + transform.right * moveDistance;
        StartCoroutine(MoveBlock());
    }

    IEnumerator MoveBlock()
    {
        while (true)
        {
            Vector3 targetPosition = movingForward ? endPosition : startPosition;
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            movingForward = !movingForward;
            yield return null;
        }
    }
}
