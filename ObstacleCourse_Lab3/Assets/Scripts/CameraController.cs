using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 5f, -7.5f);

    void LateUpdate()
    {
        transform.position = target.position + offset;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject cone1 = GameObject.FindGameObjectWithTag("Cone1");

        if (Vector3.Distance(player.transform.position, cone1.transform.position) < 1.0f)
        {
            offset = new Vector3(0f, 5f, 7.5f);
        }
        transform.LookAt(target);
    }
}
