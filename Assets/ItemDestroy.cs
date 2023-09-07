using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとアイテムの距離
    private float differenceItem;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんとアイテムの位置（z座標）の差を求める
        this.differenceItem = unitychan.transform.position.z - this.transform.position.z;

        //ある程度ユニティちゃんがアイテムを通りすぎたらアイテムを消す
        if (this.differenceItem > 5)
        {
            Destroy(gameObject);
        }
    }
}
