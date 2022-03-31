using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSE : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
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
        audioSource.clip = audioClip;

        return audioSource;
    }
}
