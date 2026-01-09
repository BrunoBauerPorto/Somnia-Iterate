using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerEsgoto : MonoBehaviour
{
    public GameObject camLiquid1, camLiquid2, camLiquid3, arrowLiquid1, arrowLiquid2, arrowLiquid3;
    public Camera cam1, cam2, cam3, mainCamera;
    Rect r, r2, r3;
    public Material liquid1, liquid2, liquid3;
    private const string fillProperty = "_Fill";
    public Animator animLuna;
    private const float goal = 1f / 3f; // 0.3333333
private const float epsilon = 0.0005f; // tolerância

    public static bool activeLiquid1, activeLiquid2, activeLiquid3, liquid1Check, liquid2Check, liquid3Check;
    void Awake()
    {
        animLuna.SetLayerWeight(0,0f);
        animLuna.SetLayerWeight(1,1f);
        liquid1.SetFloat(fillProperty,1);
        liquid2.SetFloat(fillProperty,0);
        liquid3.SetFloat(fillProperty,0);
    }
    void Start()
    {
        liquid1Check = false;
        liquid2Check = false;
        liquid3Check = false;
    }

    bool IsEqual(float a, float b)
{
    return Mathf.Abs(a - b) < epsilon;
}

    // Update is called once per frame
    void Update()
    {
        cam1.rect = r;
        cam2.rect = r2;
        cam3.rect = r3;
        if (Luna_Basic.liquid1 == true)
        {
            Luna_Basic.liquid2 = false;
            arrowLiquid1.SetActive(true);
            r.x = 0f;
            r.y = 0f;
            r.width =1f;
            r.height =1f;
            r2.x = 0.2f;
            r2.y = 0.8f;
            r2.width = 0.2f;
            r2.height = 0.2f;
            cam1.rect = r;
            cam2.rect = r2;
            if(Luna_Basic.liquid2== false)
            {
                cam2.depth = 3;
                cam1.depth = 2;
                cam3.depth = 1;
                
            }
            
        }
        else { arrowLiquid1.SetActive(false); }

        if (Luna_Basic.liquid2 == true)
        {
            Luna_Basic.liquid3 = false;
            arrowLiquid2.SetActive(true);
            r2.x = 0f;
            r2.y = 0f;
            r2.width =1f;
            r2.height =1f;
            r3.x = 0.2f;
            r3.y = 0.8f;
            r3.width = 0.2f;
            r3.height = 0.2f;
            cam2.rect = r2;
            cam3.rect = r3;
            if(Luna_Basic.liquid3 == false)
            {
                cam3.depth = 3;
                cam2.depth = 2;
                cam1.depth = 1;
            }
        }
        else {arrowLiquid2.SetActive(false);}

        if (Luna_Basic.liquid3 == true)
        {
            Luna_Basic.liquid1 = false;
            arrowLiquid3.SetActive(true);
            r3.x = 0f;
            r3.y = 0f;
            r3.width =1f;
            r3.height =1f;
            r.x = 0.2f;
            r.y = 0.8f;
            r.width = 0.2f;
            r.height = 0.2f;
            cam3.rect = r3;
            cam1.rect = r;
            if(Luna_Basic.liquid1 == false)
            {
                cam1.depth = 3;
                cam3.depth =2;
                cam2.depth = 1;
            }
            
            
        }
        else {arrowLiquid3.SetActive(false);}

        if ( IsEqual(liquid1.GetFloat(fillProperty), goal) &&
        IsEqual(liquid2.GetFloat(fillProperty), goal) &&
        IsEqual(liquid3.GetFloat(fillProperty), goal) )
    {
        ProgressoGeral.fase2Completa = true;
            SceneManager.LoadScene("Fase Principal");

    }

        if(ProgressoGeral.fase1Completa == true )
        {
            Debug.Log("Está funcionando");
        }
        
    }
}