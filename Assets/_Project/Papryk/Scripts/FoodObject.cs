using UnityEngine;

public class FoodObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyArea"))
        {
            Destroy(gameObject);
        }
    }
}
