using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    /// <summary>
    /// 召喚英雄的金錢
    /// </summary>
    public static int moneys;
    [Tooltip("初始金錢")]public int initialMoney = 10;
    [Tooltip("金錢畫面")]public Text moneysText;


    private void Start()
    {
        moneys = initialMoney;

    }

    private void Update()
    {
        moneysText.text = moneys.ToString();
    }

    public static void Consumption(int money)
    {
        moneys -= money;
    }
    public static void Obtain()
    {
        moneys += 1;
    }
}
