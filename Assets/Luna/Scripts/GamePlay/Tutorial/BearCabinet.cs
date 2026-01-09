using UnityEngine;

public class BearCabinet : MonoBehaviour
{
    public static bool cabinetBear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cabinetBear = false;
    }


    public void OpenCabinet()
    {
        cabinetBear = true;
    }
}
