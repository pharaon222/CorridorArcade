using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    public int rotationSpeed = 40;
    public int coins = 0;
    public bool gameOver = false;
    private float _horizontalInput;
    private float _verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = 0;
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) //создали условие которое проверяет что еще не конец игры и позволяет игроку двигаться
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * _verticalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.right * _horizontalInput * Time.deltaTime * speed);
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * _horizontalInput);
            // if (Input.GetKey(KeyCode.W))
            // {
            //     transform.Translate(Vector3.forward * Time.deltaTime * speed);
            // }
        }
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.tag == "Obstacle")
    //     {
    //         gameOver = true;
    //         Debug.Log("вы проиграли");
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            coins++;
        }
        if (other.gameObject.CompareTag("Door"))
        {
            if (transform.localScale.x >= 2.0f)
            {
                Debug.Log("вы выиграли");
            }
            else
            {
                Debug.Log("вы проиграли");
            }
        }
       
    }
}