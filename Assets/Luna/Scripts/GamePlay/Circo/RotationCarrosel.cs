using UnityEngine;

public class RotationCarrosel : MonoBehaviour
{
    public GameObject PrincipalCarrossel;
    [SerializeField] LeanTweenType loopType;
    void Start()
    {
        LeanTween.init();
         LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 360f, 4f).setLoopType(loopType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
