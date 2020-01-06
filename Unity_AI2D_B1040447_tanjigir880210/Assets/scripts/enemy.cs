﻿using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("移動速動"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 10;

    public Transform checkPoint;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 4);
    }

    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        r2d.AddForce(-transform.right * speed);
        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 4, 1 << 8);
        
        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "太空人")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "太空人" && collision.transform.position.y < transform.position.y + 1)
        {
            collision.gameObject.GetComponent<astronaut>().Damage(damage);
        }
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    /// /// <param name="target">玩家座標</param>
    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
