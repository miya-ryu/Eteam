using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = 3;
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        float dz = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.position = new Vector3(
            transform.position.x + dx, 1.0f, transform.position.z + dz
        );
        //if (slider.value == 0)
        //{
        //    SceneManager.LoadScene("2scene");
        //}
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

