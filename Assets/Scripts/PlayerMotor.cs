// There are some collision issues what looks like a stutter it is because I used rb to mve and player is colliding with the ground when it doesn't
// suppose to collide will figure out how to sort it later, you could also have used tranform.translate
// there is another Issue with collisions, player shouldnt die or be set back when hitting the obstacel form the side
// easy fix destroy object when hit from the side -- will also open a new game play element to explore
// score for now will be distance travelled / 10 later on will be collectables + objects destroyed from side * 10 - objects destroyed from attack 

using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Variables
    private int laneNumber; // hange to lane value as -1 is right 0 is mid and +1 is left
    private int targetPositionX; // to store change in x in seperate value
    private Rigidbody playerRigidBody;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;
    // Variables accessed through unity interface
    [SerializeField] private float forwardSpeed; // player motion on z axis
    [SerializeField] private int horizontalMovement; // fixed movement on x axis // this value should not be hard coded
    [SerializeField] private float transitionTime; //transition time to smooth motion on x
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    //[SerializeField] private float gravity;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        laneNumber = 0;
        horizontalMovement = 2;
        transitionTime = 10f;
        forwardSpeed = 2;
        minSpeed = 200;
        maxSpeed = 800;
    }

    private void Update()
    {
        SwitchLanes();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerAcceleration();
        PlayerDeceleration();
    }

    public void PlayerMove()
    {
        if (laneNumber == 0)
        {
            // middle lane
            targetPositionX = horizontalMovement * laneNumber;
        }
        else if (laneNumber == 1)
        {
            // right lane
            targetPositionX = horizontalMovement * laneNumber;
        }
        else if (laneNumber == -1)
        {
            // left lane
            targetPositionX = horizontalMovement * laneNumber;
        }

        if (forwardSpeed < minSpeed)
        {
            forwardSpeed++;
        }

        playerRigidBody.velocity = Vector3.forward * forwardSpeed * Time.deltaTime;
        //check unity doc for rigidbody.moveposition might be better suited for current case
        Vector3 targetPosition = new Vector3(targetPositionX, playerRigidBody.position.y, playerRigidBody.position.z);
        playerRigidBody.position = Vector3.Lerp(playerRigidBody.position, targetPosition, transitionTime * Time.deltaTime);
    }

    public void PlayerAcceleration()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (forwardSpeed < maxSpeed)
            {
                forwardSpeed++;
            }
        }

    }

    public void PlayerDeceleration()
    {
        if (Input.GetKey(KeyCode.UpArrow) == false)
        {
            if (forwardSpeed > minSpeed)
            {
                forwardSpeed--;
            }
        }
    }

    private void SwitchLanes()
    {

        //Input -- temp
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
