using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField] int Speed, jump;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.position -= transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey("up"))
        {
            transform.position += (new Vector3(0, jump, 0));
        }
    }

}