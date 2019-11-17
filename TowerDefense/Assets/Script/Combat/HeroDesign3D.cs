using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDesign3D : MonoBehaviour
{
    #region
    [Header("英雄身上的物件")]
    [Tooltip("旋轉位置")] public Transform heroRotate;
    [Tooltip("產生攻擊位置")] public Transform heroAttack;
    [Tooltip("攻擊招式的物件")] public GameObject attackSkill;
    [Header("個別的屬性")]
    [Tooltip("英雄名稱方便置入圖片")] public string heroName;
    [Tooltip("攻擊目標鎖定為物件的歸類")] public string attackTargetKind = "enemy";
    [Tooltip("轉動的速度"), Range(1, 20)] public float rotationSpeed = 10f;

    [Tooltip("攻擊速度")] public float attackSpeed = 1f;
    [Tooltip("能攻擊到的範圍")] public float attackRange ;
    [Tooltip("波及到範圍")] public float spreadRange ;
    [Tooltip("攻擊傷害值")] public int attackValue ;
    [Tooltip("英雄價格")] public int price = 1;
    [Tooltip("英雄攻擊動畫")] public Animator heroAinmator;

    private float attackIntervalTime = 0f; //用來計算攻擊間隔時間
    private Transform attackTarget; //鎖定目標
    #endregion

    private void Start()
    {
        InvokeRepeating("RenewTarget", 0f, 0.5f);//從0秒開始 每0.5秒調用一次 方法
    }

    private void Update()
    {
        if (attackTarget == null)//是否有目標
            return;
        LookLockingTarget();//讓英雄看著鎖定的目標
        if (attackIntervalTime <= 0)
        {
            AttackLockingTarget();//攻擊鎖定的目標
            AttackIntervalTime();//攻擊間格時間
        }
        attackIntervalTime -= Time.deltaTime;

    }
    
    /// <summary>
    /// 設定只能在編輯中看的偵測範圍
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    /// <summary>
    /// 設定攻擊目標
    /// </summary>
    private void RenewTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(attackTargetKind);
        //將所有Tag標記為"enemy"存到陣列裡;

        float misDistance = Mathf.Infinity;      //暫時先設定為無限大
        GameObject misDistanceEnemy = null;      //暫時先設定為空的

        foreach (GameObject judgeEnemy in enemys)//找到所有敵人最近的存到misDistanceEnemy
        {       
            float judgeEnemyDistance = Vector3.Distance(transform.position, judgeEnemy.transform.position);
            //將每一個敵人與英雄之間的距離暫存
            if (judgeEnemyDistance < misDistance)
            {
                misDistance = judgeEnemyDistance;
                misDistanceEnemy = judgeEnemy;
            }
        }

        if (misDistanceEnemy != null && misDistance <= attackRange)
        {//暫存的物件裡不為空並且最點距離在攻擊範圍內時 將此目標設為攻擊目標
            attackTarget = misDistanceEnemy.transform;
        }
        else
        {
            attackTarget= null;
        }
    }

    /// <summary>
    /// 讓英雄面對目標並計算轉向速度
    /// </summary>
    private void LookLockingTarget()
    {
        //儲存與目標的位置
        Quaternion lookEnemy = Quaternion.LookRotation(attackTarget.position - transform.position);
        //儲存與目標的角度
        Vector3 TemporaryStorage = Quaternion.Lerp(heroRotate.rotation, lookEnemy, Time.deltaTime * rotationSpeed).eulerAngles;
        //改變角度
        heroRotate.rotation = Quaternion.Euler(0f, TemporaryStorage.y, 0f);
    }

    /// <summary>
    /// 取得英雄攻擊的腳本、並輸出傷害值
    /// </summary>
    private void AttackLockingTarget()
    {
        Debug.Log("攻擊");
        //heroAinmator.SetBool("Fit", true);//播放攻擊動畫
        //建立攻擊
        GameObject openFire = (GameObject)Instantiate(attackSkill, heroAttack.position, heroAttack.rotation);
        HeroAccack heroAccack = openFire.GetComponent<HeroAccack>();
        if (heroAccack != null)//是否目標還在 給予數值
        {
            heroAccack.Search(attackTarget, spreadRange, attackValue);
        }
    }
    
    /// <summary>
    /// 攻擊間格時間
    /// </summary>
    private void AttackIntervalTime()
    {
        Debug.Log("結束");
        //heroAinmator.SetBool("Fit", false);//取消動畫
        attackIntervalTime = 1f / attackSpeed;
        
    }
}
