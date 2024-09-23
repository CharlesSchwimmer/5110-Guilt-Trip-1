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
    public GameObject[] interactibles;
    private Vector3 input;
    public Vector3 currentPosition;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
        Vector3 currentPosition = transform.position;
        RoomChecker(currentPosition);
        GameObject interactible = ClosestObject(currentPosition, playerActDistance, interactibles);
        if (interactible != null && Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance)
        {
            Debug.Log(interactible.name);
        }
       /* if (GetRoom(interactible) = room)
        {

        }
        //if (interactible.GetComponent<room>() = room)
       */
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

    public GameObject ClosestObject(Vector3 origin, float range, IEnumerable<GameObject> gameObjects)
    {
        GameObject closest = null;
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
