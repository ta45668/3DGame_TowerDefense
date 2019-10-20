using System.Collections;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    #region 
    [Header("產生敵人的設定")]
    [Tooltip("敵人物件")] public Transform enemyTransform;
    [Tooltip("敵人產生位置")] public Transform generateLocation;

    [Tooltip("間格時間")] public float waveInterval = 5;
    [Tooltip("敵人數量")] public int enemyQuantity = 0;
    private float reciprocalTime = 5f;//暫存倒數的時間

    #endregion

    private void Update()

    {
        ReciprocalTime();
    }

    /// <summary>
    /// 每一波的產生
    /// </summary>
    private void ReciprocalTime()
    {
        if (reciprocalTime<=0)
        {
            StartCoroutine(EceryGenerateQuantity());
            reciprocalTime = waveInterval;
        }
        reciprocalTime -= Time.deltaTime;
    }

    /// <summary>
    /// 每波敵人之間的間隔
    /// </summary>
    /// <returns></returns>
    IEnumerator EceryGenerateQuantity()
    {
        enemyQuantity++;
        for (int i = 0; i < enemyQuantity; i++)
        {
            EnemyGenerateLocation();
            yield return new WaitForSeconds(0.5f);
        }
    }

    /// <summary>
    /// 敵人生成的位置
    /// </summary>
    private void EnemyGenerateLocation()
    {
        Instantiate(enemyTransform,generateLocation.position,generateLocation.rotation);
    }
}
