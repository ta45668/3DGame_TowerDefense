using UnityEngine;

public class 建立管理 : MonoBehaviour
{

    public static 建立管理 instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private 砲塔藍圖 要建立的砲塔;
    public GameObject 建立砲塔特效;

    public bool 判斷建立 { get { return 要建立的砲塔 != null; } }
    public bool 擁有金錢 { get { return 分數.金錢 >= 要建立的砲塔.價格; } }

    public void Set建立砲塔(砲塔藍圖 塔)
    {
        要建立的砲塔 = 塔;
    }
    public void 建立砲塔位置(Node node)
    {
        if (分數.金錢 < 要建立的砲塔.價格)
        {
            Debug.Log("錢不夠");
            return;
        }
        分數.金錢 -= 要建立的砲塔.價格;
        GameObject 塔 = (GameObject) Instantiate(要建立的砲塔.預設物件, node.取得建立的座標(), Quaternion.identity);
        node.設置砲塔 = 塔;

        GameObject 效果 = (GameObject) Instantiate(建立砲塔特效, node.取得建立的座標(), Quaternion.identity);
        Destroy(效果,5f);

    }
}
