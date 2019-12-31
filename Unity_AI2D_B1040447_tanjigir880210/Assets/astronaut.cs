
using UnityEngine;

public class astronaut : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string astronautName = "太空人";
    public bool pass = false;

    private Rigidbody2D r2d;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // 更新事件:每秒執行約 60 次
    private void Update()
    {
        r2d.AddForce(new Vector2(speed, 0));
    }
}
