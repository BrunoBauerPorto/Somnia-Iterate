using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialChecks : MonoBehaviour
{

    public GameObject handle;

    



    void Update()
    {
        
            if(Luna_Basic.onDoor == true)
            {
            if (Inventory.key == true)
                {
                handle.GetComponent<Animator>().enabled = true;
                }
            }
    }



    void OpenDoor()
    {
        SceneManager.LoadScene("TransitionFasePrincipal");
    }

}


