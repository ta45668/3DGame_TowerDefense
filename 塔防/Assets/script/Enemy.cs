using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("敵人屬性")]
    public float speed = 10f;
    public int hp = 100;
    public int money = 50;
    private Transform pointTarget;
    private int point = 0;
    public GameObject deathParticle;

    private void Start()
    {
        pointTarget = LocationPoint.points[0];
    }

    public void Hurt(int hurtValue)
    {

    }
}

