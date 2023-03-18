using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource leftAudioSource;
    public AudioSource rightAudioSource;

    public bool testing = false;
    void Start()
    {
        if (testing) {
            StartCoroutine(testSound());
        }
        
    }



    void playLeftAudio() {
        leftAudioSource.Play();
    }

    void playRightAudio() {
        rightAudioSource.Play();
    }

    
    IEnumerator testSound()
{
    playLeftAudio();
    yield return new WaitForSeconds(1);

    playRightAudio();
    yield return new WaitForSeconds(1);
     StartCoroutine(testSound());
}
}
