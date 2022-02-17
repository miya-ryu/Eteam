using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField] int Speed, jump;

    private Rigidbody rb;

    //前回の Position
    private Vector3 lastpos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //前回からどこに進んだかをベクトルで取得
        Vector3 diff = transform.position - lastpos;
        //前回のPositionの更新
        lastpos = transform.position;

        if(diff.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }

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