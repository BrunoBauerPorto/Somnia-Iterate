using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    void Update()
    {
         
        transform.position = Vector3.Lerp(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
    }
}
