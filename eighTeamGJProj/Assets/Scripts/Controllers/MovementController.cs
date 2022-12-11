using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float rotSpeed = 15f;
    private float defMoveSpeed = 6f;
    public float moveSpeed;

    public float zBound = 10f;
    public float xBound = 10f;

    private CharacterController _charController;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = defMoveSpeed;
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ConstrainPlayerPosition();
    }

    void PlayerMovement()
    {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        if (horInput != 0 || verInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = verInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }        


        movement *= Time.deltaTime;
        _charController.Move(movement);
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    public void ChangeSpeed(bool status)
    {
        if (status)
        {
            moveSpeed = moveSpeed * 2f;
        }
        else
        {
            moveSpeed = defMoveSpeed;
        }
    }

    public void DecreaseSpeed(bool status)
    {
        if (status)
        {
            moveSpeed = moveSpeed * 0.5f;
        }
        else
        {
            moveSpeed = defMoveSpeed;
        }
    }
}
