
using UnityEngine;

public class astronaut : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string astronautName = "太空人";
    public bool pass = false;

    private Rigidbody2D r2d;
    // private Transform tra;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        // tra = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.D)) transform.eulerAngles = new Vector3(0, 180, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles = new Vector3(0, 180, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void FixedUpdate()
    {
        // Debug.Log(Input.GetAxis("Horizontal"));
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
}
