using UnityEngine;
/// <summary>
/// 英雄建立的管理
/// </summary>
public class GenerateHeroManagement : MonoBehaviour
{
    public static GenerateHeroManagement instance;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private HeroDesign heroDesign;//英雄的設計圖
    public GameObject generateParticle;//英雄產生的特效

    /// <summary>
    /// 判斷是否有英雄要建立
    /// </summary>
    public bool SetJudge { get { return heroDesign != null; } }
    /// <summary>
    /// 讓建立英雄位置知道是否足夠金錢建立英雄
    /// </summary>
    public bool MoneyJudge { get { return  Money.moneys>= heroDesign.cont; } }

    /// <summary>
    /// 等待要建立的英雄物件
    /// </summary>
    /// <param 要建立的英雄="prefab"></param>
    public void SetHero(HeroDesign prefab)
    {
        heroDesign = prefab;
    }

    /// <summary>
    /// 等待指定的英雄產生點來建立英雄並且使用特效
    /// </summary>
    /// <param 指定的英雄產生點="point"></param>
    public void SetEnemyPosition(HeroGenerationPoint point)
    {
        if (Money.moneys < heroDesign.cont)//判斷金額是否還足夠
        {
            Debug.Log("錢不夠");
            return;
        }
        Money.moneys -= heroDesign.cont;
        //所有金錢減去建立英雄的金額
        GameObject hero = (GameObject)Instantiate(heroDesign.prefab, point.GeneratingTargetVector(), Quaternion.identity);
        point.hero = hero;
        //建立英雄
        GameObject 效果 = (GameObject)Instantiate(generateParticle, point.GeneratingTargetVector(), Quaternion.identity);
        Destroy(效果, 5f);
        //使用特效
    }

}
