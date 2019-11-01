using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 英雄產生點
/// </summary>
public class HeroGenerationPoint : MonoBehaviour
{
    #region
    [Header("生成英雄點位屬性")]
    [Tooltip("指向目標的顏色")]public Color colorTarget;
    [Tooltip("餘額不足的顏色")]public Color colorNotMoney;
    public GameObject hero;//英雄的物件
    public Vector3 adjustmentHero;//微調英雄位置

    private Renderer storageRenderer;//產生點的渲染器
    private Color colorOriginal;//保存原本的顏色

    GenerateHeroManagement GHM;//英雄建立的管理
    #endregion

    private void Start()
    {
        storageRenderer = GetComponent<Renderer>();
        colorOriginal = storageRenderer.material.color; //保存原色

        GHM = GenerateHeroManagement.instance;
    }

    /// <summary>
    /// 回傳英雄建立的位置(微調在此)
    /// </summary>
    /// <returns></returns>
    public Vector3 GeneratingTargetVector()
    {
        return transform.position + adjustmentHero;
    }

    /// <summary>
    /// 顯示金錢是否足夠的顏色
    /// </summary>
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;//是否滑鼠有在物件上

        if (!GHM.SetJudge)
            return;//是否有英雄要設置 有往下 沒跳出
        if (hero !=null)
        {
            return;
        }
        GHM.SetEnemyPosition(this);
        
    }

    /// <summary>
    /// 指向生成點時改變它的顏色來確認
    /// </summary>
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;//是否滑鼠有在物件上
        
        if (!GHM.SetJudge)
            return;//是否有英雄要設置 有往下 沒跳出

        if (GHM.MoneyJudge)//顯示金錢是否足夠去改變顏色
        {
            storageRenderer.material.color = colorTarget;
        }
        else
        {
            storageRenderer.material.color = colorNotMoney;
        }
    }

    /// <summary>
    /// 改回原本的顏色
    /// </summary>
    void OnMouseExit()
    {
        storageRenderer.material.color = colorOriginal;
    }
}
