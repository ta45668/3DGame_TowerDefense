using System.Collections;
using UnityEngine;

/// <summary>
/// 英雄設計圖 為了改變建立不同英雄 的暫存
/// </summary>
[System.Serializable]
public class HeroDesign
{
    /// <summary>
    /// 英雄物件
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// 英雄所需金額
    /// </summary>
    public int cont;
}
