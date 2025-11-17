using UnityEngine;

public class TrainController : MonoBehaviour
{
    public static TrainController Instance;

    public float startSpeed = 3f;
    public float speedIncrease = 1.2f;
    private float speed;
    private bool isMoving = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        speed = startSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void StopTrain()
    {
        isMoving = false;

        // score qo‘shiladi
        GameManager.Instance.AddScore();

        // poyezdni boshiga qaytar
        ResetTrain();

        // tezlikni oshirish
        speed += speedIncrease;

        // yana harakatga tushish
        isMoving = true;
    }

    void ResetTrain()
    {
        // boshlang‘ich joyga qaytarish (StartPos obyektidan)
        transform.position = GameObject.Find("StartPos").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StopZone"))
        {
            GameManager.Instance.GameOver();
            isMoving = false;
        }
    }

    // StopButton bosilganda ishlaydi
    public void OnStopButtonPressed()
    {
        StopTrain();
    }
}
