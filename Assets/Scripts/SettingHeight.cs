using UnityEngine;

public class SettingHeight : MonoBehaviour
{
    public float height = 0.5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrowBooster"))
        {
            transform.localScale += new Vector3(height, height, height);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle") && transform.localScale.x >= 1)
        {
            transform.localScale -= new Vector3(height, height, height);
        }
    }
}
