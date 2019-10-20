
using UnityEngine;

public class 怪物 : MonoBehaviour
{
    public float 速度 = 10f;
    public int 生命值 = 100;
    public int 怪物金錢 = 50;
    private Transform 目標;
    private int 第幾個定位點 = 0;
    public GameObject 死亡特效;

    void Start()
    {
        目標 = 定位點.points[0];
    }

    public void 受到傷害(int 傷害值)
    {
        生命值 -= 傷害值;
        if (生命值 <= 0)
        {
            死亡();
        }
    }
    void 死亡()
    {
        GameObject 毀滅特效 = (GameObject)Instantiate(死亡特效, transform.position, Quaternion.identity);
        Destroy(毀滅特效, 5f);

        分數.金錢 += 怪物金錢;

        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = 目標.position - transform.position;
        transform.Translate(dir.normalized * 速度 * Time.deltaTime,Space.World);
        //怪物移動到每個定位點的時間計算
        if(Vector3.Distance(transform.position,目標.position)<= 0.4f)
        {
            取得下一個定位點();
            //如果怪物到達定位點時，取的下一個定位點繼續進行下一步
        }
    }
    void 取得下一個定位點()
    {
        if (第幾個定位點 >= 定位點.points.Length - 1)
        {
            終點();
            return;
            //如果定位點為最後一個時，讓怪物消失
        }
        第幾個定位點++;
        目標 = 定位點.points[第幾個定位點];
    }

    void 終點()
    {
        分數.主塔血量--;
        Destroy(gameObject);
    }

}
