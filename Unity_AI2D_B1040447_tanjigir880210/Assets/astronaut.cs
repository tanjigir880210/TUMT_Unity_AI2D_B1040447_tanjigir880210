
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
        Debug.Log(Input.GetAxis("Horizontal"));
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
}
