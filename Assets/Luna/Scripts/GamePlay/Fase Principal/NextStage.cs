using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("TransitionEsgoto");
        }
    }
}
