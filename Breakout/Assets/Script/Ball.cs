using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private	AudioSource	_wall;		        // AudioSorceを格納する変数の宣言
    private AudioSource _wallBottom;
    private AudioSource _block;
    private AudioSource _bar;
    public AudioClip	wall_Sound;		    // 効果音を格納する変数の宣言
    public AudioClip    bottom_Sound;
    public AudioClip    block_Sound;
    public AudioClip    bar_Sound;
    public GUIStyle gui_gameClear;          // ゲームクリア用のGUIStyle
    public GUIStyle gui_gameOver;           // ゲームオーバー用
    private float speed;    
    private bool gameClear;                 // クリアフラグ
    private bool gameOver;                  // ゲームオーバーフラグ


   

    void Start()
    {
        _wall = gameObject.AddComponent<AudioSource>();   // AudioSorceコンポーネントを追加し、変数に代入
        _wallBottom = gameObject.AddComponent<AudioSource>();
        _block = gameObject.AddComponent<AudioSource>();
        _bar = gameObject.AddComponent<AudioSource>();
        _wall.clip = wall_Sound;       // 鳴らす音(変数)を格納
        _wallBottom.clip = bottom_Sound;
        _block.clip = block_Sound;
        _bar.clip = bar_Sound;
        gameOver = false;
        gameClear = false;
        _bar.loop = false;
        _wall.loop = false;		
        _wallBottom.loop = false;
        _block.loop = false;
        speed = 15.0f;
        this.GetComponent<Rigidbody>().AddForce(
           (transform.right + transform.up) * speed,
           ForceMode.VelocityChange);
    }

    private void checkBlockAll()
    {
        if (GameObject.FindWithTag("Block") == null)
        {
            gameClear = true;                               // ブロックが見つからない場合、クリアフラグを立てる
            speed = 0;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;    // ボールの速度をゼロにする
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bar")
        {
            _bar.Play();
        }
            if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
            _block.Play();
        }
        if (collision.gameObject.tag == "WallBottom")
        {
            Destroy(collision.gameObject);
            _wallBottom.Play();
        }
        if(collision.gameObject.tag == "WallTop" || collision.gameObject.tag == "Wall_LR")
        {
            _wall.Play();		// 音を鳴らす
        }
        checkBlockAll();	// ブロックの確認
    }
    void Update()
    {
        //画面下の出たら
        if (this.GetComponent<Transform>().position.y <= -40)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;    // ボールの速度をゼロにする
            gameOver = true;
        }
        
        //反射角度の修正
        else if (Mathf.Abs(this.GetComponent<Rigidbody>().velocity.x) < 5 && gameClear != true)
        {
            this.GetComponent<Rigidbody>().AddForce(
            (transform.right + transform.up) * 2,
            ForceMode.VelocityChange);
        }

        else if (Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 5 && gameClear != true)
        {
            this.GetComponent<Rigidbody>().AddForce(
            (transform.right + transform.up) * 2,
            ForceMode.VelocityChange);
        }
    }

    
    void OnGUI()
    {
        // 現在のボールの速度を表示
        GUI.Label(new Rect(0, 0, 200, 20), "" + this.GetComponent<Rigidbody>().velocity);

        if (gameClear)
        {      
            // クリアフラグがたっていたら、ラベル表示.
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "GameClear", gui_gameClear);
            
        }
        if(gameOver)
        {
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "GameOver", gui_gameOver);
        }
    }
}