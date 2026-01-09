using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("Arrays")]
    public Sprite[] imagens;
    public string[] Textos;
    public float typeDelay;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip soundPlaying;

    bool isTyping = false;
    Coroutine typingCoroutine;

    [Header("Important")]
    public TMP_Text TMPro;
    public Image image;
    public Button button;
    public Sprite bearSprite;
    public Animator animator, lunaAnimator;
    [SerializeField] LeanTweenType loopType;

    public GameObject clickHand, luna, triggerDialogue;

    public static bool isDialogue;

    public int index = 0;
    public bool buttonWasClicked = false;

    void Start()
    {
        isDialogue = true;
        button.interactable = false;
        LeanTween.init();
        animator.enabled = true;
        lunaAnimator.SetBool("Walk", false);
        lunaAnimator.SetBool("Hiding", false);
        lunaAnimator.SetBool("Crawl", false);
        

        // Configura o primeiro diálogo
        TMPro.maxVisibleCharacters = 0;
        image.sprite = imagens[index];
        TMPro.text = Textos[index];

        StartCoroutine(TypeText());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            buttonClick();
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        button.interactable = false;
        
        TMPro.maxVisibleCharacters = 0;

        for (int i = 0; i <= TMPro.text.Length; i++)
        {
            audioSource.PlayOneShot(soundPlaying);
            TMPro.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }

        isTyping = false;
        button.interactable = true;
        ClickHandAnimation();
    }

    

    public void buttonClick()
    {
        // Evita clicar durante a digitação
        if (isTyping) return;

        buttonWasClicked = true;

        // Verifica se ainda há falas disponíveis
        if (index + 1 >= Textos.Length)
        {
            // Fim do diálogo
            EndDialogue();
            return;
        }

        // Avança a fala
        index++;

        TMPro.maxVisibleCharacters = 0;
        image.sprite = imagens[index];
        TMPro.text = Textos[index];

        StartCoroutine(TypeText());

        LeanTween.alpha(clickHand.GetComponent<RectTransform>(), 0, 0.5f);
        clickHand.SetActive(false);
    }

    void EndDialogue()
    {
        animator.SetBool("DialogoSaida", true);
        gameObject.SetActive(false); 
        triggerDialogue.SetActive(false);
        isDialogue = false;
    }

    public void ClickHandAnimation()
    {
        LeanTween.alpha(clickHand.GetComponent<RectTransform>(), 1, 1);
        LeanTween.scale(clickHand,
            new Vector3(0.252012871f, 0.0277541667f, 0.466667000f), 1)
            .setEaseInBack()
            .setLoopType(loopType);
    }

    private void OnEnable()
    {
        luna.GetComponent <Luna_Basic>().enabled = false;
    }

    private void OnDisable()
    {
        luna.GetComponent<Luna_Basic>().enabled = true;
    }
}
