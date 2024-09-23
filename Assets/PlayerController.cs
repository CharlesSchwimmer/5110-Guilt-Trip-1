using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Entity
{
    [Header("Player Stats")]
    public float playerActDistance;
    public float moveSpeed;
    private bool isMoving;

    [Header("Interactibles")]
    #region
    public Entity[] interactibles;
    private Vector3 input;
    public Vector3 currentPosition;
    public GameObject myPrefab;
    #endregion
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
        Vector3 currentPosition = transform.position;
        RoomChecker(currentPosition);
        Entity interactible = ClosestObject(currentPosition, playerActDistance, interactibles);
        Interact(currentPosition, interactible);
    }

    private void Interact(Vector3 currentPosition, Entity interactible)
    {
        if (interactible != null && Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance)
        {
            Debug.Log(interactible.name);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (interactible && Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance && interactible.myRoom == myRoom)
            {
                Instantiate(myPrefab, currentPosition, Quaternion.identity);
                Debug.Log(interactible.ReadText());
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
            myRoom = 1;
        }
        else if (currentPosition.x < 7.55 && currentPosition.y > 5.55)
        {
            myRoom = 2;
        }
        else { myRoom = 3; }
    }

    public Entity ClosestObject(Vector3 origin, float range, IEnumerable<Entity> gameObjects)
    {
        Entity closest = null;
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
