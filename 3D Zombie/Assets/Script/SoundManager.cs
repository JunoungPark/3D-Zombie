using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Sound(int element)
    {
        audioSource.PlayOneShot(audioClip[element]);
    }
    // Update is called once per frame
    
}
