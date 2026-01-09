using UnityEngine;

public class Object2 : MonoBehaviour
{
        public static bool object2;
    public string objectTrigger;
    public MonoBehaviour targetScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        object2 = false;
    }

   

    void OnTriggerEnter(Collider other)
    {
        if (other.name == objectTrigger)
        {
            object2 = true;
            targetScript.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
