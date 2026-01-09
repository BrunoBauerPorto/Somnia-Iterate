using UnityEngine;

public class OwlMove : MonoBehaviour
{
    public Transform target;
    public Transform luna;
    public float speed = 2f;
    public Animator owlAnim;
    void Update()
    {
        if (EnemyNav.gameOver == true)
        {
            owlAnim.SetTrigger("Attack");
        transform.position = Vector3.Lerp(
        transform.position,
        luna.position,
        Time.deltaTime * speed
    );
        }
        if(ChangeCamera.owlPosition == true)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);

        }
        

        Vector3 direction = luna.position - transform.position;

        // Se existe alguma direção para olhar
        if (direction != Vector3.zero)
        {
            if (EnemyNav.gameOver == false) {
                // Rotação desejada
                Quaternion desiredRotation = Quaternion.LookRotation(direction);

                // Rotação suave
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    desiredRotation,
                    speed * Time.deltaTime
                );
            } else { transform.rotation = transform.rotation; }
            
        }
    }

    public void ActiveMove()
    { target.gameObject.SetActive (true); }
}
