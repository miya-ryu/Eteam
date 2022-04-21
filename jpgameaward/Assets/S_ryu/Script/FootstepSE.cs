using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSE : MonoBehaviour
{
    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;
    [SerializeField] AudioClip audioClip3;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource = CreateAudioSource();
    }

    public void PlayFootstepSE(string eventName)
    {
        audioSource.Play();
    }

    private AudioSource CreateAudioSource()
    {
        var audioGameObject = new GameObject();
        audioGameObject.name = "FootstepSE";
        audioGameObject.transform.SetParent(gameObject.transform);

        var audioSource = audioGameObject.AddComponent<AudioSource>();

        return audioSource;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            audioSource.clip = audioClip1;
        }

        if (collision.gameObject.tag == "Hasi")
        {
            audioSource.clip = audioClip2;
        }
    }


}
