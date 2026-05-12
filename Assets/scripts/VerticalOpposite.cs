
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{

    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private bool isMoving = false;
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        startPos = transform.position;

        transform.position = new Vector3(startPos.x, startPos.y + moveDistance, startPos.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            if (transform.position.y >= startPos.y + moveDistance)
            {
                isMoving = false;
            }
        }

        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;

            if (transform.position.y <= startPos.y)
            {
                isMoving = true;
            }
        }
    }
}

