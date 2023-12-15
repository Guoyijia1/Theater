using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Collider2D minuteCollider;
    public Collider2D hourCollider;
    public GameObject canvas;

    private bool minuteCollided = false;
    private bool hourCollided = false;

    private void Update()
    {
        if (minuteCollided)
        {
            Debug.Log("Minute handle attach the box");
        }

        if (hourCollided)
        {
            Debug.Log("HOur handle attach the box");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == minuteCollider)
        {
            minuteCollided = true;
        }
        else if (other == hourCollider)
        {
            hourCollided = true;
        }

        CheckCollision();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == minuteCollider)
        {
            minuteCollided = false;
        }
        else if (other == hourCollider)
        {
            hourCollided = false;
        }
    }

    void CheckCollision()
    {
        if (minuteCollided && hourCollided)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
