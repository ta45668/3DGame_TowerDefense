using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    [Header("Camera")]
    public Vector3 v3_TargetPos;
    [Header("Mouse")]
    public Vector3 v3_MousePos;
    [Header("NEW")]
    public Vector3 v3_NewPos;

    [Header("要移動的物件")]
    public Transform hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        v3_TargetPos = Camera.main.WorldToScreenPoint(hero.position);
        v3_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, v3_TargetPos.z);
        v3_NewPos = Camera.main.ScreenToWorldPoint(v3_MousePos);
        hero.position = new Vector3(v3_NewPos.x, -4.5f, v3_NewPos.z);*/
    }
    /// <summary>
    /// 完成物件拖移(還需要了解程式碼)
    /// </summary>
    void OnMouseDown()//當點擊螢幕的時候
    {
        v3_TargetPos = Camera.main.WorldToScreenPoint(hero.position);
        v3_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, v3_TargetPos.z);
        v3_NewPos = Camera.main.ScreenToWorldPoint(v3_MousePos);
        hero.position = new Vector3(v3_NewPos.x, -5.0f, v3_NewPos.z);//-5.0=角色站在地板的高度
    }
    void OnMouseDrag()//當滑動螢幕的時候
    {
        v3_TargetPos = Camera.main.WorldToScreenPoint(hero.position);
        v3_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, v3_TargetPos.z);
        v3_NewPos = Camera.main.ScreenToWorldPoint(v3_MousePos);
        hero.position = new Vector3(v3_NewPos.x, -5.0f, v3_NewPos.z);
    }

}
