using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS CLASS IMPLEMENTS 
// PLAYER'S  GAME LOGIC AND PLAYER'S CONTROLLER. 

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody ball;
    public float speed;
    Vector3 force;
    public float upwardForce;
    Vector3 movement;
    //private float moveHorizontal, moveVertical;
    // Start is called before the first frame update
    private void Start()
    {
        ball = GetComponent<Rigidbody>();
         
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        ball.AddForce(movement * speed);


        //Condition for the Player Jump.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _JUMP_BLOCK_();
        }
        
    }
    public void _JUMP_BLOCK_()
    {
        ball.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
            transform.localScale += new Vector3(0.5F, 0.5F, 0.5f);
        }
    }

}
