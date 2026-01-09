using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger_PushPull : MonoBehaviour
{
    public static bool onPushPull;

    public GameObject pushPullButton, dropButton;
    public Transform holdingLuna, luna, lookTarget, pushPull;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onPushPull = false;
        pushPullButton.SetActive(false);
        dropButton.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (pushPull == null)
            {
                pushPull = transform;
            }
            pushPullButton.SetActive(true);
            
        }

        else { pushPull.SetParent(null); pushPull.position = pushPull.position; }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (onPushPull == false)
            {
                dropButton.SetActive(false);
            }
        if (onPushPull == true)
        {
            pushPull.SetParent(holdingLuna);
            StartCoroutine(Holding());
            dropButton.SetActive(true);
            
        }
        }
    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pushPull = null;
            pushPullButton.SetActive(false);
        }
    }

    IEnumerator Holding()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 currentPosition = pushPull.position;
        currentPosition.x = holdingLuna.position.x;
        currentPosition.z = holdingLuna.position.z;
    }

    public void LookAt()
    {
        if (pushPull != null)
        {
            Vector3 lookTarget = new Vector3(pushPull.position.x, luna.position.y, pushPull.position.z);
            luna.LookAt(lookTarget);
        }
    }
}
