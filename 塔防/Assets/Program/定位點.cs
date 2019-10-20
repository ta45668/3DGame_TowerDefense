using UnityEngine;

public class 定位點 : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        //此陣列為子物件的數量
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            //儲存所有子物件，也就是儲存定位點
        }
    }
}
