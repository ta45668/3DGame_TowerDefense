using System.Collections;
using UnityEngine;
/// <summary>
/// 敵人產生、波次、數量
/// </summary>
public class GenerateMonster : MonoBehaviour
{
    #region 
    [Header("產生敵人的設定")]
    [Tooltip("敵人物件")] public Transform enemyTransform;
    [Tooltip("敵人產生位置")] public Transform generateLocation;

    [Tooltip("間格時間")] public float waveInterval = 5;
    [Tooltip("敵人數量")] public int enemyQuantity = 0;
    private float reciprocalTime = 5f;//倒數的時間

    #endregion

    private void Update()

    {
        ReciprocalTime();
    }

    /// <summary>
    /// 倒數的時間為0產生敵人並重製時間
    /// </summary>
    private void ReciprocalTime()
    {
        if (reciprocalTime<=0)
        {
            StartCoroutine(EceryGenerateQuantity());//產生敵人
            reciprocalTime = waveInterval;//重製時間
        }
        reciprocalTime -= Time.deltaTime;//時間倒數
    }

    /// <summary>
    /// 每波增加敵人數量，敵人之間的間隔設定
    /// </summary>
    /// <returns></returns>
    IEnumerator EceryGenerateQuantity()
    {
        enemyQuantity++;//每次加1個敵人
        for (int i = 0; i < enemyQuantity; i++)
        {
            EnemyGenerateLocation();//敵人生成
            yield return new WaitForSeconds(0.5f);//間隔
        }
    }

    /// <summary>
    /// 敵人生成的位置
    /// </summary>
    private void EnemyGenerateLocation()
    {
        
        Instantiate(enemyTransform,generateLocation.position , generateLocation.rotation);
    }
}
