using UnityEngine;

public class RotateLerp : MonoBehaviour
{
        public float rotationStep = 90f;   // quanto gira a cada clique
    public float rotationSpeed = 3f;   // velocidade da rotação
    private float targetYRotation = 0f;
    private bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {
            // cria a rotação alvo
            Quaternion targetRotation = Quaternion.Euler(0, targetYRotation, 0);
            
            // rotaciona suavemente em direção à rotação alvo
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // verifica se já chegou bem perto da rotação final
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    // função que o botão da UI vai chamar
    public void RotateObjectRight()
    {
        if (!isRotating)
        {
            targetYRotation += rotationStep; // soma 90 graus
            isRotating = true;
        }
    }

    public void RotateObjectLeft()
    {
        if (!isRotating)
        {
            targetYRotation -= rotationStep; // subtrai 90 graus
            isRotating = true;
        }
    }
}
