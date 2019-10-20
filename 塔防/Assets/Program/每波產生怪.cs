using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 每波產生怪 : MonoBehaviour
{
    public Transform 指定怪物;
    public Transform 指定產生的位置;
    //預先設計好的拉到此位子

    public float 間隔時間 = 5f;
    private float 倒數時間 = 2f;
    private int 怪物數量 = 0;

    public Text 顯示每波的倒數時間;


    void Update()
    {
        if (倒數時間 <= 0f)
        {
            StartCoroutine(波產生());
            倒數時間 = 間隔時間;
        }
        倒數時間 -= Time.deltaTime;
        
        顯示每波的倒數時間.text = Mathf.Floor(倒數時間).ToString();
        //Mathf.Floor 無條件捨去小數
    }

    IEnumerator 波產生()
    {
        怪物數量++;
        //Debug.Log("怪物出來了");
        for (int i = 0; i < 怪物數量; i++)
        {
            產生怪物();
            yield return new WaitForSeconds(0.5f);
            //每波的所有怪物間隔幾秒放出
        }

    }

    void 產生怪物()
    {
        Instantiate(指定怪物, 指定產生的位置.position, 指定產生的位置.rotation);
    }
}
