using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float paddingLeft;

    [SerializeField]
    float paddingRight;

    [SerializeField]
    float paddingTop;

    [SerializeField]
    float paddingBottom;


    Vector2 rawInput;
    Vector2 bottomLeft; // left pos
    Vector2 topRight;

    //called even if disabled
    private void Awake()
    {
        InitBounds();
    }
    void Update()
    {
        rawInput.x = Input.GetAxis("Horizontal");
        rawInput.y = Input.GetAxis("Vertical");

        Move();



    }

    void Move()
    {
        //to keep value cons regardless of fps
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();
        //clamp limits between 
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, bottomLeft.x + paddingLeft, topRight.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, bottomLeft.y + paddingBottom, topRight.y - paddingTop);

        transform.position = newPos;
    }

    void InitBounds()
    {
        // basic of bounds
        // 0,1    1,1
        // 0,0    0,1

        Camera mainCamera = Camera.main;
        //for minimum x and y coordinates
        bottomLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        //for maximum x and y coordinates
        topRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }
}
