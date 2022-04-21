using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydownsound : MonoBehaviour
{
  

    public AudioClip sound1;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        // katana タグの付いたゲームオブジェクトと衝突したら
        if (other.gameObject.tag == "KATANA")
        {
    

            audioSource.PlayOneShot(sound1);
        }
    }
}