using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject loading;
    [SerializeField] LeanTweenType loopType;
    
    void Start()
    {
        LeanTween.init();
        LeanTween.rotateAround(loading, Vector3.forward, -360, 1f).setLoopType(loopType);
    }

   
}
