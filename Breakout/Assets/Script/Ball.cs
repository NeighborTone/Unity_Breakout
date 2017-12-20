using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private float speed = 15.0f;    //これを追加
  

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
        if (collision.gameObject.tag == "WallBottom")
        {
            Destroy(collision.gameObject);
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        //反射角度の修正
        if (Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 3)
        {
            this.GetComponent<Rigidbody>().AddForce(
            (transform.right + transform.up) * speed,
            ForceMode.VelocityChange);
        }
        if (Mathf.Abs(this.GetComponent<Rigidbody>().velocity.x) < 3)
        {
            this.GetComponent<Rigidbody>().AddForce(
            (transform.right + transform.up) * speed,
            ForceMode.VelocityChange);
        }
        //画面下の出たら
        if(this.GetComponent<Transform>().position.y <= -40)
        {
            //まだ
        }
    }
}