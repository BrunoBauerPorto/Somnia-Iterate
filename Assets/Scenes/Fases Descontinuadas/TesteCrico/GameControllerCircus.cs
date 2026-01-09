using UnityEngine;

public class GameControllerCircus : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(ClowGreenSound.greenClow == true && ClowOrangeSound.orangeClow == false)
        {
            Debug.Log("ERROU");
        }

        if (ClowRedSound.redClow == true && ClowOrangeSound.orangeClow == true && ClowGreenSound.greenClow == false )
        {
            Debug.Log("ERROU");
        }

        if (ClowRedSound.redClow == true && ClowOrangeSound.orangeClow == false && ClowGreenSound.greenClow == false)
        {
            Debug.Log("ERROU");
        }

        if (ClowRedSound.redClow == true && ClowOrangeSound.orangeClow == true && ClowGreenSound.greenClow == true)
        {
            Debug.Log("ACERTOU");
        }
    }
}
