using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 隊伍 : MonoBehaviour
{
    public 砲塔藍圖[] _砲塔藍圖 = new 砲塔藍圖[6];
    public static 砲塔藍圖[] __砲塔藍圖 = new 砲塔藍圖[6];

    void Start()
    {
        卡排隊伍設置();
    }
    public void 卡排隊伍設置()
    {
        _砲塔藍圖[0].預設物件 = Resources.Load("砲塔 6", typeof(object)) as GameObject;
        _砲塔藍圖[0].價格 = _砲塔藍圖[0].預設物件.GetComponent<砲塔>().價格;
        __砲塔藍圖[0] = _砲塔藍圖[0];
        
        _砲塔藍圖[1].預設物件 = Resources.Load("砲塔 1", typeof(object)) as GameObject;
        _砲塔藍圖[1].價格 = _砲塔藍圖[1].預設物件.GetComponent<砲塔>().價格;
        __砲塔藍圖[1] = _砲塔藍圖[1];

        _砲塔藍圖[2].預設物件 = Resources.Load("砲塔 2", typeof(object)) as GameObject;
        _砲塔藍圖[2].價格 = _砲塔藍圖[2].預設物件.GetComponent<砲塔>().價格;
        __砲塔藍圖[2] = _砲塔藍圖[2];

        _砲塔藍圖[3].預設物件 = Resources.Load("砲塔 3", typeof(object)) as GameObject;
        _砲塔藍圖[3].價格 = _砲塔藍圖[3].預設物件.GetComponent<砲塔>().價格;
        __砲塔藍圖[3] = _砲塔藍圖[3];

        _砲塔藍圖[4].預設物件 = Resources.Load("砲塔 4", typeof(object)) as GameObject;
        _砲塔藍圖[4].價格 = _砲塔藍圖[4].預設物件.GetComponent<砲塔>().價格;
        __砲塔藍圖[4] = _砲塔藍圖[4];

        _砲塔藍圖[5].預設物件 = Resources.Load("砲塔 5", typeof(object)) as GameObject;
        _砲塔藍圖[5].價格 = _砲塔藍圖[5].預設物件.GetComponent<砲塔>().價格;
        __砲塔藍圖[5] = _砲塔藍圖[5];

        for (int i = 0; i < 6; i++)
        {
            分數.價格[i] = __砲塔藍圖[i].價格;
        }
    }
}
