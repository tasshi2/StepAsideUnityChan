using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //アイテム距離テキスト
    private GameObject soukouKyoriText;
    //アイテム出現距離距離
    private float kyori = 0;
    //１５区切り数
    private float kugiri = 80;

    // Start is called before the first frame update
    void Start()
    {

        //シーン中のSoukouKyoriTextオブジェクトを取得
        this.soukouKyoriText = GameObject.Find("SoukouKyoriText");

        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            // int num = Random.Range(1, 11);
            // if (num <= 2)
            // {
            //     //コーンをx軸方向に一直線に生成
            //     for (float j = -1; j <= 1; j += 0.4f)
            //     {
            //         GameObject cone = Instantiate(conePrefab);
            //         cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
            //     }
            // }
            // else
            // {

            //     //レーンごとにアイテムを生成
            //     for (int j = -1; j <= 1; j++)
            //     {
            //         //アイテムの種類を決める
            //         int item = Random.Range(1, 11);
            //         //アイテムを置くZ座標のオフセットをランダムに設定
            //         int offsetZ = Random.Range(-5, 6);
            //         //60%コイン配置:30%車配置:10%何もなし
            //         if (1 <= item && item <= 6)
            //         {
            //             //コインを生成
            //             GameObject coin = Instantiate(coinPrefab);
            //             coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
            //         }
            //         else if (7 <= item && item <= 9)
            //         {
            //             //車を生成
            //             GameObject car = Instantiate(carPrefab);
            //             car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
            //         }
            //     }
            // }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃん（z座標）に50プラスした値をアイテム出現距離に代入
        kyori = unitychan.transform.position.z + 50;

        //SoukouKyoriTextに獲得した点数を表示(追加)
        this.soukouKyoriText.GetComponent<Text>().text = unitychan.transform.position.z + "";

        //アイテム出現距離が区切り数を超えるたびにアイテム出現をするを区切りが３６０以内まで繰り返す
        if (kyori > kugiri && kugiri < 360)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, kugiri);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, kugiri + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, kugiri + offsetZ);
                    }
                }
            }
            //オブジェクトを配置したら区切り関数をプラス１５
            kugiri += 15;
        }
    }
}