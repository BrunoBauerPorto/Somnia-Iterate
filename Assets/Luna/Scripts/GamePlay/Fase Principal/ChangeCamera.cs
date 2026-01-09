using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera camMain, camInit;
    public static bool owlPosition = false;
    //public GameObject coruja;
    




    public void ChangeCam()
    {
        camMain.depth = 5;
        camInit.depth = 1;
        owlPosition = true;
        //coruja.SetActive(true);
    }
}
