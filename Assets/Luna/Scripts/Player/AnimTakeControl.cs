using UnityEngine;

public class AnimTakeControl : MonoBehaviour
{
    public static bool isTaking;
    public GameObject bearHold;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bearHold.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
        public void TakingItem()
    {
        isTaking = true;
    }

    public void DestroyParticle()
    {
        Destroy(Luna_Basic.pickItem.gameObject.GetComponent<ParticleSystem>());
    }

    public void EndTaking()
    {
        isTaking = false;
        Destroy(Luna_Basic.pickItem.gameObject, 1f);
        if (Inventory.bear == true)
        {
            bearHold.SetActive(true);
        }
    }

    
}
