using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surinuke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("すり抜けた！");
        GameObject Object = GameObject.FindWithTag("Ashiba");

        GetComponent<Collider>().enabled = false;

        if (other.gameObject.CompareTag("Ashiba"))
        {
            Debug.Log("当たっている");
            GameObject child = transform.FindChild("Ashiba").gameObject;
            Collider collider = this.gameObject.GetComponentInChildren<BoxCollider>();
            collider.isTrigger = false;
        }
    }
}
