using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 2.0f; 
    public bool moving;

    public float speed;

    public float jump;



    Vector3 movingDir = Vector3.zero;
    // Start is called before the first frame update
    CharacterController Controller;

    private void Start()
    {
        Controller = PlayerManager.instance.Controller;
    }

    // Update is called once per frame 
    void Update()
    {
        Move(PollKeys());
    }
    public void Move(PlayerInputPacket packet)
    {

        if (movingDir.x != 0 || movingDir.z != 0)
        {
            moving = true;
            movingDir = Vector3.Normalize(Quaternion.Euler(0, packet.Rotation, 0) * movingDir);
        }
        if (packet.Keys[4])
        {
            speed = 5;
        }
        else if (speed == 5) speed = 2;
        if (packet.Keys[5])
        {
            //animator.SetBool("Jump", true);
            movingDir.y += jump;
        }
        else
        {
            //.animator.SetBool("Jump", false);
            if (!Controller.isGrounded)
            {

                movingDir.y -= 2;
            }
        }
        // set local rotation 
        //player.cameraTransform.localRotation = Quaternion.Euler(client.movement.MouseY / 2, 0, 0);
        transform.localRotation = Quaternion.Euler(0, packet.Rotation, 0);
        if (moving)
        {
            movingDir *= speed * Time.deltaTime;
        }
         Controller.Move(movingDir);

    }

    PlayerInputPacket PollKeys()
    {
        PlayerInputPacket packet = new PlayerInputPacket();
        packet.Keys = new bool[8];
        packet.Keys[0] = Input.GetKey(KeyCode.W);
        packet.Keys[1] = Input.GetKey(KeyCode.S);
        packet.Keys[2] = Input.GetKey(KeyCode.A);
        packet.Keys[3] = Input.GetKey(KeyCode.D);
        packet.Keys[4] = Input.GetKey(KeyCode.LeftShift);
        packet.Keys[5] = Input.GetKeyDown(KeyCode.Space);
        packet.Keys[6] = Input.GetMouseButton(1);
        packet.Keys[7] = Input.GetMouseButton(0);
        /*     if (Input.GetKey(KeyCode.LeftAlt))
           {

               motor.speed += Input.GetAxis("Mouse ScrollWheel");
               motor.speed = Mathf.Clamp(motor.speed, 2, 5f);
           } 

           if (mouse)
           {
               client.movement.MouseY -= (Input.GetAxisRaw("Mouse Y") * 2);
               client.movement.MouseY = Mathf.Clamp(client.movement.MouseY, -35f, 35f);
               packet.Rotation  += (Input.GetAxisRaw("Mouse X") * 2); 
               packet.Rotation %= 360f;
           }*/
        return packet;
    }
    void spawn()
    {

    }
}
public class PlayerInputPacket
{
    public bool[] Keys;
    public float Rotation;
}
