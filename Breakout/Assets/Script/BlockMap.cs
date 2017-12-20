using UnityEngine;
using System.Collections;

public class BlockMap : MonoBehaviour
{

    public GameObject blockPrefab;
    public int placeX;          ////横に並べる個数
    public int placeY;          ////縦に並べる個数
    public Transform topWall;   //上の壁の参照を追加
    public float totalDepth;    ////縦に並べる座標
    // Use this for initialization
    void Start()
    {
        //配置する座標を設定

        //Vector3 placePosition = new Vector3(-10, 0, 0);

        Vector3 placePosition = new Vector3(
          topWall.position.x - topWall.localScale.x / 2 + blockPrefab.transform.localScale.x / 2,
          topWall.position.y - topWall.localScale.y / 2 - blockPrefab.transform.localScale.y /2 -1 ,
          0);

        //配置する回転角を設定
        Quaternion q = new Quaternion();
        q = Quaternion.identity;

        //幅と奥行きを調整
        Vector3 localscale = blockPrefab.transform.localScale;
        localscale.x = topWall.localScale.x / placeX;
        localscale.y = totalDepth / placeY;
        blockPrefab.transform.localScale = localscale;

        ////配置
        //for (int i = 0; i < placeX; i++)
        //    {
        //        Instantiate(blockPrefab, placePosition, q);
        //        placePosition.x += blockPrefab.transform.localScale.x + 1;
        //    }
        //配置
        for (int i = 0; i < placeY; i++)
        {
            Vector3 currentPlacePosition
                = placePosition
                - Vector3.up * blockPrefab.transform.localScale.y * i;
            for (int j = 0; j < placeX; j++)
            {
                Instantiate(blockPrefab, currentPlacePosition, q);
                currentPlacePosition.x += blockPrefab.transform.localScale.x;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}