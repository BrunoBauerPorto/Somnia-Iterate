using UnityEngine;

public class ArcMove : MonoBehaviour
{
    public static bool orange, green, red;
    public Transform pointA;
    public Transform pointOrange, pointGreen, pointRed;
    Transform pointB;
    public float duration = 1f;
    public float arcHeight = 2f;
    public static bool launch;
    public Animator animLuna;

    private float t = 0f;
    public static bool moving = false;

    void Awake()
    {
        red = false;
        orange = false;
        green = false;
        launch = false;
    }

    private void Start()
    {
        transform.SetParent(pointA);
    }
    void Update()
    {
        if(orange == true)
        {
            pointB = pointOrange;
            animLuna.SetTrigger("LaunchBall");
        }

        if(green == true)
        {
            pointB = pointGreen;
            animLuna.SetTrigger("LaunchBall");
        }

        if(red == true)
        {
            pointB = pointRed;
            animLuna.SetTrigger("LaunchBall");
        }
        if(launch == true)
        {
            StartArc();
        }
        if (moving)
        {
            t += Time.deltaTime / duration;

            // Posição linear entre A e B
            Vector3 linearPos = Vector3.Lerp(pointA.position, pointB.position, t);

            // Criando o arco (parábola)
            float height = 4 * arcHeight * t * (1 - t); 
            // Fórmula da parábola: pico no meio, sobe e depois desce

            // Aplicando altura ao Y
            linearPos.y += height;

            transform.position = linearPos;

            if (t >= 1f)
                moving = false;
        }
    }

    public void StartArc()
    {
        //t = 0f;
        transform.SetParent(null);
        moving = true;
    }



    public void Orange()
    {
        orange = true;
        red = false;
        green = false;
        Luna_Basic.velocity = 0;
    }

    public void Red()
    {
        red = true;
        orange = false;
        green = false;
        Luna_Basic.velocity = 0;
    }

    public void Green()
    {
        green = true;
        red = false;
        orange = false;
        Luna_Basic.velocity = 0;
    }
}
