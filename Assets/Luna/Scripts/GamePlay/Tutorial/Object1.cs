using UnityEngine;

public class Object1 : MonoBehaviour
{
    public static bool object1;
    public string objectTrigger;
    public MonoBehaviour targetScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        object1 = false;
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.name == objectTrigger)
        {
            object1 = true;
            targetScript.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
