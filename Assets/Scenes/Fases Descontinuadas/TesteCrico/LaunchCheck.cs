using UnityEngine;

public class LaunchCheck : MonoBehaviour
{
    

    public void Launch()
    {
        ArcMove.launch = true;
        Luna_Basic.velocity = 3;
    }
}
