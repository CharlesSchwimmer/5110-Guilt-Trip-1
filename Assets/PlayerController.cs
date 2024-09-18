using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector3 input;
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
    }
   public void Movement()
    {
        Vector3 Movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += Movement * moveSpeed * Time.deltaTime;
    }
}
