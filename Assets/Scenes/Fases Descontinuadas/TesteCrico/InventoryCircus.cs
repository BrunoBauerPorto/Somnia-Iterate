using UnityEngine;

public class InventoryCircus : MonoBehaviour
{
    public static bool ball1;
    public static bool ball2;
    public static bool ball3;

    public GameObject ballGreen, ballRed, ballOrange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball1 = false;
        ball2 = false;
        ball3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball1 == true && ArcMove.green == true)
        {
            ballGreen.SetActive(true);    
        }

        if (ball2 == true && ArcMove.red == true)
        {
            ballRed.SetActive(true);
        }

        if (ball3 == true && ArcMove.orange == true)
        {
            ballOrange.SetActive(true);
        }

    }
}
