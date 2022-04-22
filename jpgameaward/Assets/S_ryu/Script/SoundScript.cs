using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip AttackClip;
    [SerializeField] private AudioClip JumpClip;
    [SerializeField] private AudioClip DamageClip;
    [SerializeField] private AudioClip BGMClip;
    [SerializeField] private AudioClip GameClearClip;
    [SerializeField] private AudioClip GameOverClip;
    [SerializeField] private AudioClip CursorClip;
    [SerializeField] private AudioClip PushClip;

    public void Attack()
    {
        audioSource.PlayOneShot(AttackClip, 0.3f);
    }
    public void Jump()
    {
        audioSource.PlayOneShot(JumpClip, 0.3f);
    }
    public void Damage()
    {
        audioSource.PlayOneShot(DamageClip, 0.5f);
    }
    public void BGM()
    {
        audioSource.PlayOneShot(BGMClip, 0.3f);
    }
    public void GameClear()
    {
        audioSource.PlayOneShot(GameClearClip, 0.3f);
    }
    public void GameOver()
    {
        audioSource.PlayOneShot(GameOverClip, 0.3f);
    }
    public void Cursor()
    {
        audioSource.PlayOneShot(CursorClip, 0.3f);
    }
    public void Push()
    {
        audioSource.PlayOneShot(PushClip, 0.3f);
    }
}
