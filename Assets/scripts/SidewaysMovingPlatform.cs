using UnityEngine;

public class SidewaysMovingPlatform : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float moveDistance = 5f;

    private bool isMoving = true;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

            if (transform.position.z >= startPos.z + moveDistance)
            {
                isMoving = false;
            }
        }

        else
        {
            transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;

            if (transform.position.z <= startPos.z)
            {
                isMoving = true;
            }
        }
    }
}

