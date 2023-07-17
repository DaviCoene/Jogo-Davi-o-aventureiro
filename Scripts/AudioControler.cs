using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    public AudioSource Song;
    public AudioClip[] Songs;
    // Start is called before the first frame update
    void Start()
    {
        AudioClip Fundo = Songs[0];
        Song.clip = Fundo;
        Song.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
