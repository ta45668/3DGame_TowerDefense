using UnityEngine;
using UnityEngine.UI;


public class 牌 : MonoBehaviour
{
    建立管理 _建立管理;
    隊伍 _隊伍;
    //砲塔 _砲塔;
    //public 砲塔藍圖[] _砲塔藍圖 = new 砲塔藍圖[6];
    void Start()
    {
        _建立管理 = 建立管理.instance;
        //卡牌設置();

    }
    /*public void 卡牌設置()//設置圖片 Image = 砲塔
    {
        foreach (Image 子 in GetComponentsInChildren<Image>())
        {
            子.sprite = Resources.Load(_砲塔.UI圖, typeof(Sprite)) as Sprite;
        }
       
    }*/
    
    public void 召喚卡牌_1()
    {

        _建立管理.Set建立砲塔(隊伍.__砲塔藍圖[0]);
    }
    public void 召喚卡牌_2()
    {
        _建立管理.Set建立砲塔(隊伍.__砲塔藍圖[1]);
    }
    public void 召喚卡牌_3()
    {
        _建立管理.Set建立砲塔(隊伍.__砲塔藍圖[2]);
    }
    public void 召喚卡牌_4()
    {
        _建立管理.Set建立砲塔(隊伍.__砲塔藍圖[3]);
    }
    public void 召喚卡牌_5()
    {
        _建立管理.Set建立砲塔(隊伍.__砲塔藍圖[4]);
    }
    public void 召喚卡牌_6()
    {
        _建立管理.Set建立砲塔(隊伍.__砲塔藍圖[5]);
    }
}
