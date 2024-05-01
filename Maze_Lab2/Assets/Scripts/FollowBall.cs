using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;

    void LateUpdate()
    {
        transform.position = ball.position + new Vector3(0, 0, 0);
        transform.LookAt(ball.position);
    }
}
