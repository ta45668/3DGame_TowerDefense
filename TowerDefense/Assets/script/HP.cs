using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    /// <summary>
    /// 守護的生命值
    /// </summary>
    public static int totalHP;
    [Tooltip("初始生命")]public int initialHP = 10;
    public Text totalHPText;

    private void Start()
    {
        totalHP = initialHP;
    }

    private void Update()
    {
        totalHPText.text = totalHP.ToString();
    }

    public static void Damage()
    {
        totalHP -= 1;
    }

}
