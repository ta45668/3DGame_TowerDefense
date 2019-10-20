using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 子彈 : MonoBehaviour
{
    private Transform 目標;
    public GameObject 擊中特效;

    public float 數度 = 70f;
    public int 攻擊值 = 50;
    public float 攻擊範圍 = 0f;

    public void 尋找(Transform _目標)
    {
        目標 = _目標;
    }


    void Update()
    {
        if (目標 == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = 目標.position - transform.position;
        float 與敵人的距離 = 數度 * Time.deltaTime;

        if (dir.magnitude <= 與敵人的距離)
        {
            命中目標();
            return;
        }

        transform.Translate(dir.normalized * 與敵人的距離, Space.World);

    }

    void 命中目標()
    {
        GameObject 使用特效 = (GameObject)Instantiate(擊中特效, transform.position, transform.rotation);
        
        Destroy(使用特效, 2f);

        if (攻擊範圍 > 0f)
        {
            範圍();
        }else
        {
            損壞敵人(目標);
        }

        Destroy(gameObject);
        
    }

    void 範圍()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 攻擊範圍);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "敵人")
            {
                損壞敵人(collider.transform);
            }
            
        }
    }
    void 損壞敵人(Transform 目標怪物)
    {
        怪物 _怪物 = 目標怪物.GetComponent<怪物>();
        if (_怪物 != null)
        {
            _怪物.受到傷害(攻擊值);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 攻擊範圍);
    }
}
