using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KATANA_Effect : MonoBehaviour
{
    private bool isPlaying;
    [SerializeField] ParticleSystem particle;

    public Text text;

    private void Start()
    {
        isPlaying = false;
    }
    void KATANA_effect()
    {
        particle.Play(true);
    }
    void ShowText1()
    {
        text.text = "あれ？";
        Debug.Log("あれ？");
    }

    void ShowText2()
    {
        text.text = "ここはどこ？";
    }

    void ShowText3()
    {
        text.text = "おーい！";
    }

    void ResetText()
    {
        text.text = "";
    }
}
