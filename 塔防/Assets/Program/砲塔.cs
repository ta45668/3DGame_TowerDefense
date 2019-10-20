using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class 砲塔 : MonoBehaviour
{
    private Transform 目標;

    [Header("需要的物件")]
    public Transform 旋轉零件;
    public GameObject 設置子彈;
    public Transform 槍口;
    [Header("屬性")]
    public string 攻擊目標種類 = "敵人";
    public float 攻擊範圍 = 15f;
    public float 轉速 = 10f;
    public float 射速 = 1f;
    private float 射擊間隔時間 = 0f;
    public int 價格;
    public string UI圖;
    [Header("雷射砲塔")]
    public bool 雷射bool = false;
    public LineRenderer lineRenderer;

    void Start()
    {
        InvokeRepeating("更新目標", 0f, 0.5f); 
    }

    void 更新目標()
    {
        GameObject[] 敵人S = GameObject.FindGameObjectsWithTag(攻擊目標種類);
                                             //將所有Tag標記為"敵人"存到陣列裡;

        float 最短距離 = Mathf.Infinity;     //暫時先設定為無限大
        GameObject 最近的敵人 = null;        //暫時先設定為空的

        foreach (GameObject 選擇的敵人 in 敵人S)
        {       //選擇的敵人 in(目標) 為 敵人S 的陣列，判斷此陣列的每一個

            float 與敵人的距離 = Vector3.Distance(transform.position, 選擇的敵人.transform.position);
            //與敵人的距離 = 自己 與 選擇的敵人 之間距離

            if (與敵人的距離 < 最短距離)
            {
                最短距離 = 與敵人的距離;
                最近的敵人 = 選擇的敵人;
            }
        }

        if (最近的敵人 != null &&/*並且*/最短距離 <= 攻擊範圍)
        {
            目標 = 最近的敵人.transform;
        }
        else
        {
            目標 = null;
        }

    }

    void Update()
    {
        if (目標 == null)
        {
            if (雷射bool)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            return;
        }
            

        鎖定目標();
        if (雷射bool)
        {
            雷射();
        }
        else
        {
            if (射擊間隔時間 <= 0f)
            {
                射擊();
                射擊間隔時間 = 1f / 射速;

            }

            射擊間隔時間 -= Time.deltaTime;
        }
    }

    void 鎖定目標()
    {
        Vector3 dir = 目標.position - transform.position;
        Quaternion 看著目標 = Quaternion.LookRotation(dir);
        Vector3 旋轉 = Quaternion.Lerp(旋轉零件.rotation, 看著目標, Time.deltaTime * 轉速).eulerAngles;
        旋轉零件.rotation = Quaternion.Euler(0f, 旋轉.y, 0f);
    }
    void 雷射()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, 槍口.position);
        lineRenderer.SetPosition(1, 目標.position);
    }
    void 射擊()
    {
        //Debug.Log("射擊!!");
        GameObject 發射子彈 = (GameObject) Instantiate(設置子彈, 槍口.position, 槍口.rotation);
        子彈 _子彈 = 發射子彈.GetComponent<子彈>();

        if (_子彈 != null)
            _子彈.尋找(目標);

    }

    private void OnDrawGizmosSelected()
    {//點選到此物件顯示他的攻擊範圍
        Gizmos.color = Color.red;                       //邊線為紅色
        Gizmos.DrawWireSphere(transform.position, 攻擊範圍);//設定為球體與範圍
    }
}
