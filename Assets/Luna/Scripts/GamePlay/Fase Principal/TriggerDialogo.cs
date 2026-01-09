using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public GameObject dialogo, Luna;
    public Animator LunaAnim;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="Luna 1")
        {
            LunaAnim.SetBool("Walk", false);
            Luna.GetComponent<Luna_Basic>().enabled = false;
            Luna_Basic.velocity = 0f;
            dialogo.SetActive(true);
        }
    }
}
