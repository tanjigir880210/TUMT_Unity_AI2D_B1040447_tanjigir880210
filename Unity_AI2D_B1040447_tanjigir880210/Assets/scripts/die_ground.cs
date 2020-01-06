using UnityEngine;

public class die_ground : MonoBehaviour
{
    public int damage = 100;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "太空人")
        {
            collision.gameObject.GetComponent<astronaut>().Damage(damage);

            print("123");
        }
    }
}
