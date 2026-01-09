using UnityEngine;
using System.Collections;

public class GameController2 : MonoBehaviour
{
    public GameObject camCoruja1, camCoruja2, camCoruja3, lightCoruja1, lightCoruja2, lightCoruja3, arrowGolden, arrowSilver, arrowBlack, victory, bear, doorShadow, transitionShadow, doorSewer, transitionSewer, shadow, corujaEnemy;
    public static bool activeCoruja1, activeCoruja2, activeCoruja3, corujaBlackCheck, corujaSilverCheck, corujaGoldenCheck;
    public float tempo;

    public Camera camFinish, camIniti;
    void Start()
    {
        camCoruja1.SetActive(false);
        camCoruja2.SetActive(false);
        camCoruja3.SetActive(false);
        lightCoruja1.SetActive(false);
        lightCoruja2.SetActive(false);
        lightCoruja3.SetActive(false);
        activeCoruja1 = false;
        activeCoruja2 = false;
        activeCoruja3 = false;
        corujaBlackCheck = false;
        corujaSilverCheck = false;
        corujaGoldenCheck = false;
        bear.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Luna_Basic.coruja1 == true && activeCoruja1 == true)
        {
            camCoruja1.SetActive(true);
            
            arrowGolden.SetActive(true);
        }
        else { camCoruja1.SetActive(false);  arrowGolden.SetActive(false);}

        if (Luna_Basic.coruja2 == true && activeCoruja2 == true)
        {
            camCoruja2.SetActive(true);
            
            arrowSilver.SetActive(true);
        }
        else { camCoruja2.SetActive(false);   arrowSilver.SetActive(false); }

        if (Luna_Basic.coruja3 == true && activeCoruja3 == true)
        {
            camCoruja3.SetActive(true);
            
            arrowBlack.SetActive(true);
        }
        else { camCoruja3.SetActive(false); arrowBlack.SetActive(false); }

        if (corujaGoldenCheck == true)
        {
            lightCoruja1.SetActive(true);
        }
        else { lightCoruja1.SetActive(false); }

        if (corujaSilverCheck == true)
        {
            lightCoruja2.SetActive(true);
        }
        else { lightCoruja2.SetActive(false); }

        if (corujaBlackCheck == true)
        {
            lightCoruja3.SetActive(true);
        }
        else { lightCoruja3.SetActive(false); }
        
        if(corujaGoldenCheck == true && corujaSilverCheck == true && corujaBlackCheck == true)
        {
            shadow.SetActive(false);
            corujaEnemy.SetActive(false);
            StartCoroutine(TrocarCameraPorUmSegundo());

            ProgressoGeral.fase1Completa = true;
            doorShadow.GetComponent<Animator>().enabled = true;
            doorSewer.GetComponent<Animator>().enabled = true;


        }

        if(ProgressoGeral.fase1Completa == true)
        {
            shadow.SetActive(false);
            doorShadow.GetComponent<Animator>().enabled = true;
            doorSewer.GetComponent<Animator>().enabled = true;
        }
    }

    IEnumerator TrocarCameraPorUmSegundo()
    {
        camIniti.enabled = false;
        camFinish.enabled = true;

        yield return new WaitForSeconds(tempo);

        camIniti.enabled = false;
        camFinish.enabled = true;
    }
}
