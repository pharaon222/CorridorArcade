using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    public bool gameOver = false;
    private float _horizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) //создали условие которое проверяет что еще не конец игры и позволяет игроку двигаться
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * _horizontalInput * Time.deltaTime * speed);
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("вы проиграли");
        }
    }
}
