using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EsgotoTransicao : MonoBehaviour
{
    public Animator animLuna;

    void Awake()
    {
        animLuna.SetLayerWeight(0,0f);
        animLuna.SetLayerWeight(1,0f);
        animLuna.SetLayerWeight(2,1f);
    }


    public void Esgoto()
    {
        SceneManager.LoadScene("Esgoto");
    }
}
