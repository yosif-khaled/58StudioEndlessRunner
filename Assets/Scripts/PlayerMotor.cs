using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Variables
    private float laneNumber; // hange to lane value as -1 is right 0 is mid and +1 is left
    private float targetPositionX; // to store change in x in seperate value
    private Rigidbody playerRigidBody;
    

    public bool isMovingLeft = false;
    public bool isMovingRight = false;

    public bool isAccelerating = false;

    // Variables accessed through unity interface
    [SerializeField] private float forwardSpeed; // player motion on z axis
    [SerializeField] private float horizontalMovement; // fixed movement on x axis // this value should not be hard coded
    [SerializeField] private float transitionTime; //transition time to smooth motion on x
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    //[SerializeField] private float gravity;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        laneNumber = 0;
        horizontalMovement = 2.25f;
        transitionTime = 10f;
        forwardSpeed = 2;
        minSpeed = 200;
        maxSpeed = 1200;
    }

    private void Update()
    {
        SwitchLanes();
    }

    private void FixedUpdate()
    {
        PlayerMove();

        if (Input.GetKey(KeyCode.UpArrow) || isAccelerating)
        {
            PlayerAcceleration();
        }

        else if (!Input.GetKey(KeyCode.UpArrow) || !isAccelerating)
        {
           PlayerDeceleration();
        }
    }

    public void PlayerMove()
    {
        if (laneNumber == 0)
        {
            // middle lane
            targetPositionX = Mathf.Clamp01(0);
        }
        else if (laneNumber == 1)
        {
            // right lane
            targetPositionX = horizontalMovement;
        }
        else if (laneNumber == -1)
        {
            // left lane
            targetPositionX = -horizontalMovement;
        }

        if (forwardSpeed < minSpeed)
        {
            forwardSpeed++;
        }

        playerRigidBody.velocity = Vector3.forward * forwardSpeed * Time.deltaTime;
        //check unity doc for rigidbody.moveposition might be better suited for current case
        Vector3 targetPosition = new Vector3(targetPositionX, playerRigidBody.position.y, playerRigidBody.position.z);
        playerRigidBody.position = Vector3.Lerp(playerRigidBody.position, targetPosition, transitionTime * Time.fixedDeltaTime);
    }

    public void PlayerAcceleration()
    {
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed++;
        }
    }



    public void PlayerDeceleration()
    {
        if (forwardSpeed > minSpeed)
        {
            forwardSpeed--;
        }
    }

    private void SwitchLanes()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) || isMovingRight)
        {
            MoveRight();
            isMovingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || isMovingLeft)
        {
            MoveLeft();
            isMovingLeft = false;
        }
        else
        {
            return;
        }
    }

    public void MoveRight()
    {
        if (laneNumber == 0 || laneNumber == -1)
        {
            laneNumber++;
        }
        else
        {
            return;
        }
    }

    public void MoveLeft()
    {
        if (laneNumber == 0 || laneNumber == 1)
        {
            laneNumber--;
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Obstacle")
        {
            GameManager.gameOver = true;
        }
    }
}
