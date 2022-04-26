using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip AttackClip;
    [SerializeField] private AudioClip JumpClip;
    [SerializeField] private AudioClip DamageClip;
    [SerializeField] private AudioClip GameClearClip;
    [SerializeField] private AudioClip GameOverClip;
    [SerializeField] private AudioClip CursorClip;
    [SerializeField] private AudioClip PushClip;
    [SerializeField] private AudioClip HelseClip;
    [SerializeField] private AudioClip EnemyClip;
    [SerializeField] private AudioClip BosEnemyClip;

    public bool DontDestroyEnabled = true;

    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

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
    public void GameClear()
    {
        audioSource.PlayOneShot(GameClearClip, 0.5f);
    }
    public void GameOver()
    {
        audioSource.PlayOneShot(GameOverClip, 0.5f);
    }
    public void Cursor()
    {
        audioSource.PlayOneShot(CursorClip, 0.2f);
    }
    public void Push()
    {
        audioSource.PlayOneShot(PushClip, 0.3f);
    }
    public void Helse()
    {
        audioSource.PlayOneShot(HelseClip, 0.5f);
    }
    public void Enemy()
    {
        audioSource.PlayOneShot(EnemyClip, 0.5f);
    }
    public void BosEnemy()
    {
        audioSource.PlayOneShot(BosEnemyClip, 0.5f);
    }
}
