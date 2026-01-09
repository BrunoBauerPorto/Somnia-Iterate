using UnityEngine;

public class Cam_Follow : MonoBehaviour
{
    public Transform target;
    public float smooth;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position + offset;  
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth);   
    }
}
