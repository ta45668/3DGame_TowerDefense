using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAccack : MonoBehaviour
{
    #region
    /// <summary>
    /// 特效
    /// </summary>
    [Tooltip("擊中目標特效")]public GameObject hitParticle;
    /// <summary>
    /// 鎖定目標
    /// </summary>
    private Transform accackTarget;
    /// <summary>
    /// 飛行速度
    /// </summary>
    [Tooltip("飛行速度")] public float flightSpeed = 70f;
    /// <summary>
    /// 波及範圍
    /// </summary>
    private float spreadRange;
    /// <summary>
    /// 傷害值
    /// </summary>
    private int attackValue;
    #endregion

    /// <summary>
    /// 等英雄的資料傳進來
    /// </summary>
    /// <param 鎖定目標="target"></param>
    /// <param 波及範圍="range"></param>
    /// <param 傷害值="Value"></param>
    public void Search(Transform target, float range, int Value)
    {
        accackTarget = target;
        spreadRange = range;
        attackValue = Value;
    }

    private void Update()
    {
        if(accackTarget == null)//判斷是否有目標
        {
            Destroy(gameObject);//刪除物件
            return;
        }
        Flight();//飛向目標
    }

    /// <summary>
    /// 攻擊飛向敵人
    /// </summary>
    void Flight()
    {
        //自身與目標距離
        Vector3 dir = accackTarget.position - transform.position;
        //時速
        float targetDistance = flightSpeed * Time.deltaTime;
        //距離<=時速
        if (dir.magnitude <= targetDistance)
        {
            HitTarget();//擊中
            return;
        }
        //移動
        transform.Translate(dir.normalized * targetDistance, Space.World);
    }

    /// <summary>
    /// 擊中目標 使用特效
    /// </summary>
    void HitTarget()
    {
        //使用特效與維持時間
        GameObject useHitParticle = (GameObject)Instantiate(hitParticle, transform.position, transform.rotation);
        Destroy(useHitParticle, 0.2f);

        if (spreadRange>0f)//是否有波及範圍
        {
            SpreadRange();//波及周遭敵人
        }
        else
        {
            HurtEnemy(accackTarget);//傷害敵人
        }
        Destroy(gameObject);//刪除物件
    }

    /// <summary>
    /// 給予目標傷害值
    /// </summary>
    /// <param 傷害目標="target"></param>
    void HurtEnemy(Transform target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Hurt(attackValue);//回傳傷害值
        }
    }

    /// <summary>
    /// 設定偵測範圍
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spreadRange);
    }

    void SpreadRange()
    {
        //儲存所有在範圍內標記為敵人的物件
        Collider[] colliders = Physics.OverlapSphere(transform.position, spreadRange);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                HurtEnemy(collider.transform);//傷害敵人
            }
        }
    }
}
