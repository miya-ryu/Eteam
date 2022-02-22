using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Slider slider;
    Rigidbody rb;
    SimpleAnimation simpleAnimation;
    float speed = 6f;


    void Start()
    {
        slider.value = 3;
        rb = this.GetComponent<Rigidbody>();
        simpleAnimation = this.GetComponent<SimpleAnimation>();
    }

    void Update()
    {

        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x + dx, 0.5f);

        if (dx == 0)
        {
            simpleAnimation.Play("Default");
        }
        else
        {
            simpleAnimation.CrossFade("Run", 0.1f);
        }
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        if (dx < 0)
        {
            localAngle.y = 270.0f;
            myTransform.localEulerAngles = localAngle;
        }
        else
        {
            localAngle.y = 90.0f;
            myTransform.localEulerAngles = localAngle;
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PointDown")
        {
            if (slider.value > 0)
            {
                slider.value--;
            }
        }
        if (col.gameObject.name == "PointUp")
        {
            if (slider.value < 4)
            {
                slider.value++;
            }
        }
    }
}

