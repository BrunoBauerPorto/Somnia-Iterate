using UnityEngine;

public class RotationRodaGig : MonoBehaviour
{
    public GameObject PrincipalCarrossel;
    [SerializeField] LeanTweenType loopType;
    void Start()
    {
        LeanTween.init();
         LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 360f, 10f).setLoopType(loopType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
