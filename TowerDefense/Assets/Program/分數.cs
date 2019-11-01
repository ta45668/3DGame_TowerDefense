using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class 分數 : MonoBehaviour
{
    public static int 主塔血量;
    public int 初始血量;
    public Text 主塔血量Text;

    public static int 金錢;
    public int 初始金錢=500;
    public Text 金錢Text;

    public static int[] 價格 = new int[6];
    public Text[] 價格Text =  new Text[6];
    
    //隊伍 _隊伍;
    void Start()
    {
        金錢 = 初始金錢;
        主塔血量 = 初始血量;
    }

    public void 價格初始化()
    {
        for (int i = 0; i < 6; i++)
        {
            價格Text[i].text = 價格[i].ToString();
        }
    }

    void Update()
    {
        金錢Text.text = "$"+金錢.ToString();
        主塔血量Text.text = 主塔血量.ToString();
        價格初始化();
    }
}
