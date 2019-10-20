using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAccack : MonoBehaviour
{
    public GameObject hitParticle;
    private Transform accackTarget;
    [Tooltip("飛行速度")] public float flightSpeed = 70f;
    private float spreadRange;
    private int attackValue;

    /// <summary>
    /// 等英雄的資料傳進來
    /// </summary>
    /// <param 鎖定目標="target"></param>
    /// <param 波及範圍="range"></param>
    /// <param 傷害值="accackValue"></param>
    public void Search(Transform target, float range, int accackValue)
    {
        accackTarget = target;
        spreadRange = range;
        attackValue = accackValue;
    }

    private void Update()
    {
        if(accackTarget == null)
        {
            Destroy(gameObject);
            return;
        }
        Flight();
    }

    /// <summary>
    /// 攻擊飛向敵人
    /// </summary>
    void Flight()
    {
        Vector3 dir = accackTarget.position - transform.position;
        float targetDistance = flightSpeed * Time.deltaTime;
        if (dir.magnitude <= targetDistance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * targetDistance, Space.World);
    }

    /// <summary>
    /// 擊中目標 使用特效
    /// </summary>
    void HitTarget()
    {
        GameObject useHitParticle = (GameObject)Instantiate(hitParticle, transform.position, transform.rotation);
        Destroy(useHitParticle, 2f);

        if (spreadRange>0f)
        {
            SpreadRange();
        }
        else
        {
            HurtEnemy();
        }
        Destroy(gameObject);
    }

    void HurtEnemy()
    {

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

    }
}
