using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydownsound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip EnemyClip;

    private void OnTriggerEnter(Collider other)
    {
        // katana タグの付いたゲームオブジェクトと衝突したら
        if (other.gameObject.tag == "KATANA")
        {
            AudioSource.PlayClipAtPoint(sound1, transform.position);
        }
    }
}