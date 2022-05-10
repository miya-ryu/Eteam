using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class stageNum : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        PlayerPrefs.DeleteKey("stageNumber");
    }
}