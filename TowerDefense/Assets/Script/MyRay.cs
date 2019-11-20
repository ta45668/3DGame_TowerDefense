using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRay : MonoBehaviour
{

    public Transform hero;//卡片起始點
    [Header("計算射線與平面的交點")] public Vector3 count;//計算射線與平面的交點
    [Header("卡牌的位置")] public Vector3 test01;//卡牌的位置
    [Header("射線的方向")] public Vector3 test03;//射線的方向
    [Header("打到的位置")] public Vector3 test04;//HIT的位置
    [Header("英雄位置")] public Vector3 heroTr;

    public Transform myHero;//卡片終點
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        //ray = new Ray(hero.transform.position, test03); //設定射線方向(物體的起始點，射擊方向)
    }

    // Update is called once per frame
    void Update()
    {
        heroTr = myHero.position;
        ray = new Ray(hero.transform.position, transform.forward); //設定射線方向(物體的起始點，射擊方向)
        //ray = new Ray(hero.transform.position, test03); //設定射線方向(物體的起始點，射擊方向)
        Physics.Raycast(ray, out hit);
        if (Input.GetMouseButton(0))//當滑鼠按下去時
        {
            //Debug.Log(ray);
            test01 = new Vector3(hero.position.x, hero.position.y, hero.position.z);//查看位置
            count = test04;
            myHero.position = new Vector3((Input.mousePosition.x - 10) / 33.5f -7.5f, count.y - 0.25f, (Input.mousePosition.y - 10) / 14 - 5.0f);//英雄顯示位置
            //Debug.DrawLine(hero.transform.position, count , Color.red, 0.1f, true);//出現射線(在UNITY的編輯器裡)
            Debug.Log(hit.transform.name);//射到的東西名稱
            Debug.DrawRay(hero.transform.position, transform.forward * 10, Color.blue);
        }
        test04 = new Vector3(hit.point.x, hit.point.y, hit.point.z);//查看位置
        //Debug.DrawRay(hero.transform.position, transform.forward * 10, Color.green);
        //Debug.DrawLine(hero.transform.position, count, Color.red, 0.1f, true);//出現射線(在UNITY的編輯器裡)
    }
}
