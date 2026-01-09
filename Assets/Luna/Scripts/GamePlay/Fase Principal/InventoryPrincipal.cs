using UnityEngine;

public class InventoryPrincipal : MonoBehaviour
{
    public GameObject slot1, slot2, slot3;
    public static bool ball1;
    public static bool ball2;
    public static bool ball3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball1 == true)
        {
            slot1.SetActive(true);
        }
        if (ball2 == true)
        {
            slot2.SetActive(true);
        }
        if (ball3 == true)
        {
            slot3.SetActive(true);
        }
    }
}
