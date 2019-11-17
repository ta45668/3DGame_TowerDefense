using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRay : MonoBehaviour
{

    public Transform hero;//卡片起始點
    [Header("計算射線與平面的交點")] public Vector3 count;//計算射線與平面的交點
    [Header("卡牌的位置")] public Vector3 test01;//卡牌的位置
    [Header("平面的位置")] public Vector3 test02;//平面的位置
    [Header("射線的方向")] public Vector3 test03;//射線的方向

    public Transform myHero;//卡片終點
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        //ray = new Ray(hero.transform.position, test03); //設定射線方向(物體的起始點，射擊方向)
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(hero.transform.position, transform.forward); //設定射線方向(物體的起始點，射擊方向)
        RaycastHit hit;
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))//當滑鼠按下去時
        {
            Debug.Log(ray);
            test01 = new Vector3(hero.position.x, hero.position.y, hero.position.z);//查看位置
            test02 = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);//查看位置
            count = new Vector3(hit.transform.position.x*10.0f + hero.position.x, hit.transform.position.y, hit.transform.position.z + hero.position.y*10.0f);//計算交點位置
            myHero.position = new Vector3(count.x, count.y-0.5f, count.z);//英雄顯示位置
            Debug.DrawLine(hero.transform.position, count , Color.red, 0.1f, true);//出現射線(在UNITY的編輯器裡)
            Debug.Log(hit.transform.name);//射到的東西名稱
            Debug.DrawRay(hero.transform.position, transform.forward * 10, Color.blue);
        }
        Debug.DrawLine(hero.transform.position, count, Color.red, 0.1f, true);//出現射線(在UNITY的編輯器裡)
    }
}
