using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 10)
        {
            transform.position += new Vector3(20.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -10)
        {
            transform.position += new Vector3(-20.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
    }
}