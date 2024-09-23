using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerActDistance;
    public int room;
    public float moveSpeed;
    private bool isMoving;
    public Object[] interactibles;
    private Vector3 input;
    public Vector3 currentPosition;
    public GameObject myPrefab;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
        Vector3 currentPosition = transform.position;
        RoomChecker(currentPosition);
        Object interactible = ClosestObject(currentPosition, playerActDistance, interactibles);
        if (interactible != null && Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance)
        {
            Debug.Log(interactible.name);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (interactible && Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance && interactible.myRoom == room)
            {
                Instantiate(myPrefab, currentPosition, Quaternion.identity);

            }
            else
            {
                return;
            }
        }
    }

    private void RoomChecker(Vector3 currentPosition)
    {
        if (currentPosition.x < 7.55 && currentPosition.y < 5.55)
        {
            room = 1;
        }
        else if (currentPosition.x < 7.55 && currentPosition.y > 5.55)
        {
            room = 2;
        }
        else { room = 3; }
    }

    public Object ClosestObject(Vector3 origin, float range, IEnumerable<Object> gameObjects)
    {
        Object closest = null;
        float closestSqrDist = 0f;
        foreach (var gameObject in gameObjects)
        {
            float sqrDist = (gameObject.transform.position - origin).sqrMagnitude;
            if (!closest || sqrDist < closestSqrDist)
            {
                closest = gameObject;
                closestSqrDist = sqrDist;
            }
        }
        return closest;
    }
    public void Movement()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += Movement * moveSpeed * Time.deltaTime;
    }

}
