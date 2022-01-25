using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioData;
    public AudioClip impact;
    public bool played = false;
    public void Update()
    {
        //audioData = GetComponent<AudioSource>();
        if (!played)
        {
            audioData.PlayOneShot(impact);
            played = true;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame

}
