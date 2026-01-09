using UnityEngine;

public class Espelho : MonoBehaviour
{
public Transform target;

    void Update()
    {
        if (target == null) return;

        transform.position = new Vector3(
            transform.position.x,   
            transform.position.y,   
            target.position.z       
        );
    }
}
