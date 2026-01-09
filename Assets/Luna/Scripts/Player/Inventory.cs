using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject slot1, slot2, slot3, slot4, slot5,bearCabinet;
    public static bool key;
    public static bool bear;

    void Start()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(false);
        slot5.SetActive(false);
        bearCabinet.SetActive(false);
        key = false;
        bear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (key == true)
        {
            slot1.SetActive(true);
        }
        if (bear == true)
        {
            slot2.SetActive(true);
        }
        if (BearCabinet.cabinetBear == true)
        {
            bearCabinet.SetActive(true);
        }

    }
}
