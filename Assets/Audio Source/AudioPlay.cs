using UnityEngine;

public class AudioPlay : MonoBehaviour
{
AudioSource aud;



    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_sound(){

        aud.Play();
    }
}
