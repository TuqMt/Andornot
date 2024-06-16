using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed= 5f;
    Rigidbody rb;
    Vector3 direction;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("Run", true);
        }
        if (direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Run", false);
        }
    }
    void FixedUpdate()
    {
        if (transform.position.x<=98 || transform.position.z<=98 || transform.position.x>=2 || transform.position.z>=2)
        {
            rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
        }
    }
            
}