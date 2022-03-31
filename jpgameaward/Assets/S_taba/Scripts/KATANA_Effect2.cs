using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KATANA_Effect2 : MonoBehaviour
{
    TrailRenderer KATANA_TrailRenderer;
    //private TrailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        KATANA_TrailRenderer = GetComponent<TrailRenderer>();

        KATANA_TrailRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("B"))
        {
            KATANA_TrailRenderer.enabled = true;

            Invoke("Delete_Effect", 0.8f);
        }
    }
    void Delete_Effect()
    {

        KATANA_TrailRenderer.enabled = false;
    }
}
