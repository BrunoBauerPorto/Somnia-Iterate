using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class Luna_Basic : MonoBehaviour
{
    public static bool coruja1;
    public static bool coruja2;
    public static bool coruja3;
    public static bool liquid1;
    public static bool liquid2;
    public static bool liquid3;
    public static bool hiding;
    public static bool isCrawling;
    public bool onPushPull;
    public bool crawling;
    public static bool isHolding = false;
    private bool movingToItem = false;
    public static bool isWalking;
    public static bool onDoor;
    public bool takeItem;

    public Rigidbody rbLuna;
    public static float velocity;
    Vector3 movement, holdDirection;
    Vector3 targetHitPoint;
    public Animator animLuna;
    public Animator cabinet;
    
   
    float minPickupDistance;
    public Transform rayOrigin;
    public Transform holdPoint, pointPick;
    public static Transform pickItem;
    private GameObject heldItem, detectedItem;
    public GameObject dropButton, holdButton, camDoor, camPlayer;
    public GameObject buttonTaking;

    
    public ParticleSystem particle;
    //LineRenderer lr;

    public Camera mainCamera;

    void Start()
    {
        
        coruja1 = false;
        minPickupDistance = 0.2f;
        //lr = gameObject.AddComponent<LineRenderer>();
        //lr.startWidth = 0.02f;
        //lr.endWidth = 0.02f;
        //lr.material = new Material(Shader.Find("Unlit/Color"));
        //lr.material.color = Color.green;
        //dropButton.SetActive(false);
        holdButton.SetActive(false);
        buttonTaking.SetActive(false);
        camDoor.SetActive(false);
        crawling = false;
        hiding = false;
        isWalking = false;
        onDoor = false;
        
        
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement.Set(h, 0, v);
        Move(h, v);
        Turning(h, v);
        Animations(h, v);
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isHolding == true)
        {
            DropItem();
        }

        if(takeItem == true)
        {
            if(Input.GetButtonDown("Jump"))
            {
                TakingAnim();
            }
        }

        Vector3 origin = rayOrigin.position;
        Vector3 direction = rayOrigin.forward;
        //lr.SetPosition(0, origin);
        //lr.SetPosition(1, origin + direction * 2f);

        if (AnimTakeControl.isTaking == true)
        {
            pickItem.position = pointPick.position;
            pickItem.SetParent(pointPick);
        }

        
        
        if (heldItem == null && !movingToItem)
        {
            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, 2f))
            {
                
                if (hit.collider.CompareTag("Pickup") )
                {
                    detectedItem = hit.collider.gameObject;
                    targetHitPoint = hit.point;
                    holdButton.SetActive(true);
                    
                    if (Input.GetButtonDown("Jump") && isHolding == false)
                    {
                        TryPickup();
                    }

                }

                else
                {
                    detectedItem = null;
                    holdButton.SetActive(false);
                }

                if (hit.collider.CompareTag("Coruja1"))
                {
                    coruja1 = true;
                    detectedItem = hit.collider.gameObject;
                }
                if (hit.collider.CompareTag("Coruja2"))
                {
                    coruja2 = true;
                    detectedItem = hit.collider.gameObject;
                }
                if (hit.collider.CompareTag("Coruja3"))
                {
                    coruja3 = true;
                    detectedItem = hit.collider.gameObject;
                }

                if (hit.collider.CompareTag("Liquid1"))
                {
                    liquid1 = true;
                    detectedItem = hit.collider.gameObject;
                    mainCamera.depth = 1;
                }
                if (hit.collider.CompareTag("Liquid2"))
                {
                    liquid2 = true;
                    detectedItem = hit.collider.gameObject;
                    mainCamera.depth = 1;
                }
                if (hit.collider.CompareTag("Liquid3"))
                {
                    liquid3 = true;
                    detectedItem = hit.collider.gameObject;
                    mainCamera.depth = 1;
                }
                
            }
            else
            {
                detectedItem = null;
                holdButton.SetActive(false);
                coruja1 = false;
                coruja2 = false;
                coruja3 = false;
                liquid1 = false;
                liquid2 = false;
                liquid3 = false;
                mainCamera.depth = 5;
            }

        }
        else if (!movingToItem)
        {
            holdButton.SetActive(false);
        }

        if (heldItem != null)
        {
            
            //dropButton.SetActive(true);
        }
        else
        {
            //dropButton.SetActive(false);
        }

        if (movingToItem && detectedItem != null)
        {
            animLuna.SetBool("Walk", true);
            Vector3 targetPos = targetHitPoint;
            targetPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, velocity * Time.deltaTime);
            float dist = Vector3.Distance(transform.position, targetPos);
            if (dist <= minPickupDistance)
            {
                PickupNow();
            }
        }
        
        if (AnimTakeControl.isTaking == true)
        {
            velocity = 0;
        }
        else if (AnimTakeControl.isTaking == false && animLuna.GetBool("Hiding") == false) { velocity = 3; }

        if (onPushPull == true || animLuna.GetBool("Crawl") == true)
        {
            velocity = 1f;
        }
        else if (animLuna.GetBool("Walk")) { velocity = 3; }

    }
    void Move(float h, float v)
    {
        if (onPushPull == false)
        {
            movement = movement.normalized * velocity ; //* Time.deltaTime;
            //rbLuna.MovePosition(transform.position + movement);
            rbLuna.linearVelocity = movement;
            FixedJoystick.snapY = false;
            FixedJoystick.snapX = false;
        }
        else
        {
            if (h != 0)
            {
                FixedJoystick.snapY = true;
                FixedJoystick.snapX = false;
            }
            if (v != 0)
            {
                FixedJoystick.snapY = false;
                FixedJoystick.snapX = true;
            }
            holdDirection = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
            float dot = Vector3.Dot(movement, holdDirection);
            movement = holdDirection * dot * velocity * Time.deltaTime;
            rbLuna.MovePosition(transform.position + movement);
            if (dot < 0)
            {
                animLuna.SetBool("Pull", true);
                animLuna.SetBool("Push", false);
                animLuna.SetBool("IdlePull", false);
            }
            if (dot > 0)
            {
                animLuna.SetBool("Pull", false);
                animLuna.SetBool("Push", true);
                animLuna.SetBool("IdlePull", false);
            }
            if (dot == 0)
            {
                animLuna.SetBool("IdlePull", true);
                animLuna.SetBool("Pull", false);
                animLuna.SetBool("Push", false);
            }
        }
    }
    void Turning(float h, float v)
    {
        if (onPushPull == false)
        {
            Vector3 rot = new Vector3(h, 0, v);
            if (rot != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(rot);
            }
        }
        else
        {
            transform.rotation = transform.rotation;
        }
    }
    void Animations(float h, float v)
    {
        if (onPushPull == false)
        {
            if (hiding == false) //Se rasteijar for falso, então a booleana da animação de andar vai ser checado pelo valor de h e/ou v
            {
                isWalking = h != 0 || v != 0;
                animLuna.SetBool("Walk", isWalking);
            }
            else // Se for verdadeira, então a booleana da animação de caminhar será sempre falsa
            {
                animLuna.SetBool("Walk", false);
            }

            /* 
            Sequência de checagens em que se a variável booleana "hiding" for verdadeira 
            e o jogador movimentar o personagem, ele irá rasteijar
            */
            if (animLuna.GetBool("Walk") == false && hiding == true)
            {

                animLuna.SetBool("Hiding", true);
                if (h != 0 && v != 0)
                {
                    animLuna.SetBool("Crawl", true);
                    animLuna.SetBool("Hiding", false);
                }
                else { animLuna.SetBool("Hiding", true); animLuna.SetBool("Crawl", false); }
            }
            if (isWalking == true)
            {
                animLuna.SetBool("Hiding", false);
                hiding = false;
                velocity = 3;
            }
        }
    }
    public void TryPickup()
    {
        if (detectedItem != null && heldItem == null)
        {
            movingToItem = true;
           
            holdButton.SetActive(false);
        }
    }
    void PickupNow()
{
    animLuna.SetTrigger("OnPull");
    onPushPull = true;
    heldItem = detectedItem;
    detectedItem = null;
    movingToItem = false;

        Vector3 offset = transform.position - heldItem.transform.position;
    bool alignOnX = Mathf.Abs(offset.x) > Mathf.Abs(offset.z);

    Vector3 newPos = transform.position;

    if (alignOnX)
    {
        newPos.z = heldItem.transform.position.z;
        transform.LookAt(new Vector3(heldItem.transform.position.x, transform.position.y, transform.position.z));
    }
    else
    {
        
        newPos.x = heldItem.transform.position.x;
        
        transform.LookAt(new Vector3(transform.position.x, transform.position.y, heldItem.transform.position.z));
    }

    
    transform.position = newPos - transform.forward * 0.2f;

    
    Rigidbody rb = heldItem.GetComponent<Rigidbody>();
    if (rb != null) rb.isKinematic = true;
    heldItem.transform.SetParent(holdPoint);
}

    public void DropItem()
    {
        if (heldItem != null)
        {
            animLuna.SetTrigger("OutPull");
            onPushPull = false;
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;
            heldItem.transform.SetParent(null);
            heldItem = null;
            dropButton.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TakeIten"))
        {
            takeItem = true;
            buttonTaking.SetActive(true);
            pickItem = other.transform;
        }
    }
    void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("Cabinet"))
    {
        if (GameController.openCabinet == true && Inventory.key == true)
        {
            cabinet.SetTrigger("Open");
        }
    }    
    if (other.CompareTag("Door"))
            {
                camDoor.SetActive(true);
                camPlayer.SetActive(false);
                onDoor = true;
            }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TakeIten"))
        {
            takeItem = false;
            buttonTaking.SetActive(false);
        }
        if (other.CompareTag("Door"))
        {
            camDoor.SetActive(false);
            camPlayer.SetActive(true);
            onDoor = false;
        }
    }
    public void TakingAnim()
    {
        Destroy(particle);
        takeItem = false;
        animLuna.SetTrigger("Taking");
        buttonTaking.SetActive(false);
        if (pickItem.name == "Key")
        {
            Inventory.key = true;
        }
        if (pickItem.name == "Teddy")
        {
            Inventory.bear = true;
        }

        if (pickItem.name == "Ball1")
        {
            InventoryPrincipal.ball1 = true;
        }

        if (pickItem.name == "Ball2")
        {
            InventoryPrincipal.ball2 = true;
        }

        if (pickItem.name == "Ball3")
        {
            InventoryPrincipal.ball3 = true;
        }
        if (pickItem.name == "BallGreen")
        {
            InventoryCircus.ball1 = true;
        }

        if (pickItem.name == "BallRed")
        {
            InventoryCircus.ball2 = true;
        }
        if (pickItem.name == "BallOrange")
        {
            InventoryCircus.ball3 = true;
        }

        ItemPickup item = pickItem.GetComponent<ItemPickup>();

        if (item != null)
        {
            InventarioFaseSombra.Instance.AddItem(item.itemID, pickItem.name);
        }

    }



}
