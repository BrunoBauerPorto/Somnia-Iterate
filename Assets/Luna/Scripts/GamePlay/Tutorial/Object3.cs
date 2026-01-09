using UnityEngine;

public class Object3 : MonoBehaviour
{
        public static bool object3;
        public string objectTrigger;
    public MonoBehaviour targetScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        object3 = false;
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.name == objectTrigger)
        {
            object3 = true;
            targetScript.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
