using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionImages : MonoBehaviour
{
    public GameObject Transition;
    public string[] textos;
    public Sprite[] imagens;
    public TMP_Text TMPro;
    public Image Image;
    public AudioClip soundPlaying;
    public AudioSource audioSource;
    public float typeDelay = 0;
    public int index = 0;
    public Animator animator;

   

    void Start()
    {
        animator.SetBool("TransitionOut", false);

        TMPro.text = textos[index];
        Image.sprite = imagens[index];
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        
        TMPro.maxVisibleCharacters = 0;

        for (int i = 0; i <= TMPro.text.Length; i++)
        {
            audioSource.PlayOneShot(soundPlaying);
            TMPro.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
       
        yield return new WaitForSeconds(1f);
        animator.SetBool("TransitionOut", true);
         //yield return new WaitForSeconds(1f);
        //animator.SetBool("TransitionOut", false); 
        
        if(index +1 >= textos.Length)
        {
            
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void NextText()
    {
        animator.SetBool("TransitionOut", false);
        index++;
        StartCoroutine(TypeText());
        TMPro.text = textos[index];
        Image.sprite = imagens[index];
        
    }
 
    
}
