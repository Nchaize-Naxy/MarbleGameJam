using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class MarbleBehaviour : MonoBehaviour
{
    private BallInput ballInput;

    public Rigidbody rb;
    public Transform camera;

    public ParticleSystem ps;

    private float maxSpeed = 5;

    private bool up;
    private bool right;
    private bool left;
    private bool down;
    private bool jump;
    
    

    void Start()
    {
        ps.Stop();
        ballInput = new BallInput();
        ballInput.Movements.Up.started += goUp;
        ballInput.Movements.Up.canceled += goUp;

        ballInput.Movements.Right.started += goRight;
        ballInput.Movements.Right.canceled += goRight;

        ballInput.Movements.Left.started += goLeft;
        ballInput.Movements.Left.canceled += goLeft;

        ballInput.Movements.Down.started += goDown;
        ballInput.Movements.Down.canceled += goDown;

        ballInput.Movements.Jump.performed += jumping;

        ballInput.Enable();
    }

    void OnDestroy()
    {
        ballInput.Movements.Up.started -= goUp;
        ballInput.Movements.Up.canceled -= goUp;

        ballInput.Movements.Right.started -= goRight;
        ballInput.Movements.Right.canceled -= goRight;

        ballInput.Movements.Left.started -= goLeft;
        ballInput.Movements.Left.canceled -= goLeft;

        ballInput.Movements.Down.started -= goDown;
        ballInput.Movements.Down.canceled -= goDown;

        ballInput.Disable();
    }

    void goUp(InputAction.CallbackContext context)
    {
        if (context.started) {
            up = true;
        }

        if (context.canceled) {
            up = false;
        }
    }

    void goRight(InputAction.CallbackContext context)
    {
        if (context.started) {
            right = true;
        }

        if (context.canceled) {
            right = false;
        }
    }

    void goLeft(InputAction.CallbackContext context)
    {
        if (context.started) {
            left = true;
        }

        if (context.canceled) {
            left = false;
        }
    }

    void goDown(InputAction.CallbackContext context)
    {
        if (context.started) {
            down = true;
        }

        if (context.canceled) {
            down = false;
        }
    }

    void jumping(InputAction.CallbackContext context)
    {
        if (jump == true)
            rb.AddForce(new Vector3(0, 200, 0), ForceMode.Force);
        jump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        float impulse = collision.impulse.magnitude;
        ContactPoint contact = collision.contacts[0];
        Vector3 contactNormal = contact.normal;

        if (impulse > 2f)
        {
            ps.transform.position = contact.point;
            ps.transform.localEulerAngles = contactNormal;
            
            ps.Play();
        }
        if (contactNormal.y > Mathf.Cos(0.53f)) //allows a 30 degree slop to still give the jump back
        {
            jump = true;
        }
    }

    void Update()
    {
        if (up)
        {
            Vector3 dir = camera.transform.forward;
            rb.AddForce(dir, ForceMode.Force);
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }

        if (right)
        {
            Vector3 dir = camera.transform.forward;

            float temp = dir.x;
            dir.x = dir.z;
            dir.z = -temp;

            rb.AddForce(dir, ForceMode.Force);
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
        if (left)
        {
            Vector3 dir = camera.transform.forward;

            float temp = dir.x;
            dir.x = -dir.z;
            dir.z = temp;

            rb.AddForce(dir, ForceMode.Force);
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
        if (down)
        {
            Vector3 dir = camera.transform.forward;
            dir = -dir;
            rb.AddForce(dir, ForceMode.Force);
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }
}
