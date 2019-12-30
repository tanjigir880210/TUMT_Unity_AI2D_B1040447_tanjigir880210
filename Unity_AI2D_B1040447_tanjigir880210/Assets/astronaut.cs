
using UnityEngine;

public class astronaut : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string astronautName = "太空人";
    public bool pass = false;

    private void Start()
    {
        Debug.Log("呼叫太空人");
    }
}
