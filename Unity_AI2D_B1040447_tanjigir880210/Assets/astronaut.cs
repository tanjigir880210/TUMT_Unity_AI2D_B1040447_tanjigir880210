
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Turn(180);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Turn(0);
    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        r2d.AddForce(new Vector2(0, jump * Input.GetAxis("Jump")));
    }

    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向，左轉為 180，右轉為 0</param>>
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
}
