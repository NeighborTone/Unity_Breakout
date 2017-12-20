using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private	AudioSource	audioSource;		// AudioSorceを格納する変数の宣言.
	public	AudioClip	sound;				// 効果音を格納する変数の宣言.
    private float speed = 15.0f;    //これを追加
    private bool gameClear = false;     // クリアフラグ.
    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();   // AudioSorceコンポーネントを追加し、変数に代入.
        audioSource.clip = sound;       // 鳴らす音(変数)を格納.
        audioSource.loop = false;		// 音のループなし。
        this.GetComponent<Rigidbody>().AddForce(
           (transform.right + transform.up) * speed,
           ForceMode.VelocityChange);
    }
    private void checkBlockAll()
    {
        if (GameObject.FindWithTag("Block") == null)
        {
            gameClear = true;                               // ブロックが見つからない場合、クリアフラグを立てる
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;    // ボールの速度をゼロにする.
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();		// 音を鳴らす.
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "WallBottom")
        {
            Destroy(collision.gameObject);
        }
        checkBlockAll();	// ブロックの確認.
    }
   

   

    // Update is called once per frame
    void Update()
    {
        //反射角度の修正
        //if (Mathf.Abs(this.GetComponent<Rigidbody>().velocity.x) < 3)
        //{
        //    this.GetComponent<Rigidbody>().AddForce(
        //    (transform.right + transform.up) * speed,
        //    ForceMode.VelocityChange);
        //}
        //画面下の出たら
        if(this.GetComponent<Transform>().position.y <= -40)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;    // ボールの速度をゼロにする
            
        }
    }

    public GUIStyle gui_gameClear;      // ゲームクリア用のGUIStyle.

    void OnGUI()
    {
        // 現在のボールの速度を表示
        GUI.Label(new Rect(0, 0, 200, 20), "" + this.GetComponent<Rigidbody>().velocity);

        if (gameClear)
        {       // クリアフラグがたっていたら、ラベル表示.
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "GameClear", gui_gameClear);
            
        }
    }
}