using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private float speed = 10.0f;    //これを追加
   

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(
            (transform.right + transform.up) * speed,
            ForceMode.VelocityChange);

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
        
        //if (Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 3)
        //{
        //    this.GetComponent<Rigidbody>().velocity.y
        //}
    }
    // Update is called once per frame
    void Update()
    {

    }
}