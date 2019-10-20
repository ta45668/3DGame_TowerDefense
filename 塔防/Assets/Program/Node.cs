using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color 目標顏色;
    public Color 不夠錢的顏色;
    public Vector3 砲塔定位調整;

    [Header("玩家設定的")]
    public GameObject 設置砲塔;
    

    private Renderer rend;
    private Color 原色;

    建立管理 _建立管理;

    void Start()
    {
        rend = GetComponent<Renderer>();
        原色 = rend.material.color;

        _建立管理 = 建立管理.instance;
    }

    public Vector3 取得建立的座標()
    {
        return transform.position + 砲塔定位調整;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_建立管理.判斷建立)
            return;

        if (設置砲塔 != null)
        {
            return;
        }

        _建立管理.建立砲塔位置(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_建立管理.判斷建立)
            return;
        if(_建立管理.擁有金錢)
        {
            rend.material.color = 目標顏色;
        }else
        {
            rend.material.color = 不夠錢的顏色;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = 原色;
    }
}
