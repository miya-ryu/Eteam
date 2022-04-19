using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverArea : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        //RigidBodyを取得
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOverArea"))
        {
            Debug.Log("ステージから落ちた。");
            this.transform.position = new Vector3(-5.15f, 6.173f, 1.28f);
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
