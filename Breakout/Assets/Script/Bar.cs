using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour
{
    // 位置座標
    //private Vector3 position;
    //// スクリーン座標をワールド座標に変換した位置座標
    //private Vector3 screenToWorldPointPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //// Vector3でマウス位置座標を取得する
        //position = Input.mousePosition;
        //// Z軸修正
        //position.z = -Camera.main.transform.position.z;
        //position.y = -Camera.main.transform.position.y + 70;
       
        //// マウス位置座標をスクリーン座標からワールド座標に変換する
        //screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        //// ワールド座標に変換されたマウス座標を代入
        //gameObject.transform.position = screenToWorldPointPosition;

        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 9)
        {
            transform.position += new Vector3(10.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -9)
        {
            transform.position += new Vector3(-10.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
    }
}