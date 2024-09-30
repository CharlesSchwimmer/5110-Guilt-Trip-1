using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{

    [Header("Connectors")]
    public Entity interactibleTracker;
    public ResetFader resetFader;
    public TaskFader taskFader;
    [SerializeField] private Animator anim;
    public TaskTracker taskTracker;
    public EndGame endScreen;
    public GameObject counter;
    

    [Header("Player Stats")]
    public int myRoom;
    public float dayTimer;
    public float playerActDistance;
    public float moveSpeed;
    public bool isMoving;
    public bool canMove = false;
    public float timeTracker;
    public Vector3 originPosition;
    public bool ended = false;
    [Header("Interactibles")]
    #region
    public Entity[] interactibles;
    private Vector3 input;
    public Vector3 currentPosition;
    public GameObject myPrefab;
    #endregion
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        originPosition = rb.position;
        myRoom = 1;
        canMove = true;
        timeTracker = dayTimer;
    }
    private void Update()
    {
        if (resetFader.isResetting == false)
        {
            timeTracker -= Time.deltaTime;
        }
        DayReset();
        Movement();
        Vector3 currentPosition = transform.position;
        RoomChecker(currentPosition);
        Entity interactible = ClosestObject(currentPosition, playerActDistance, interactibles);
        Interact(currentPosition, interactible);
        interactibleTracker = interactible;
    }

    private void DayReset()
    {
        if (timeTracker <= 0)
        {
            resetFader.SwitchBool(true);
            timeTracker = dayTimer;
        }
    }


    private void Interact(Vector3 currentPosition, Entity interactible)
    {
        if (interactible != null && Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance)
        {
            interactible.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
            interactible.GetComponent<SpriteRenderer>().color = Color.white;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (interactible &&
                Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance &&
                interactible.myRoom == myRoom &&
                interactible.stage != 0)
            {
                PopUpBox popUpBox = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpBox>();
                popUpBox.PopUp(interactible);
            }
            else if (interactible &&
                Vector3.Distance(interactible.transform.position, currentPosition) < playerActDistance &&
                interactible.myRoom == myRoom &&
                interactible.stage == 0)
            {
                PopUpBox popUpBox = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpBox>();
                popUpBox.PopUp(interactible);
            }
            else
                return;
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
        if (canMove == false)
        {
            anim.SetBool("Walking", false);
            return;
        }
        else
        {
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += Movement * moveSpeed * Time.deltaTime;
            Vector3 direction = Movement.normalized;
            if (Movement != Vector3.zero)
            {
                anim.SetBool("Walking", true);
                isMoving = true;
                transform.up = direction;
            }
            else
            {
                anim.SetBool("Walking", false);
                isMoving = false;
            }
        }
    }

    public void EndGame()
    {
        for(int i = 0; i < interactibles.Length; i++)
            if (interactibles[i].stage == 0)
            {
                endScreen.Tasks[i].text = interactibles[i].successText;
            }
            else
            {
                endScreen.Tasks[i].text = interactibles[i].failText;
                endScreen.Tasks[i].color = Color.red;
            }
        counter.GetComponent<AudioSource>().enabled = false;
        endScreen.GetComponent<Canvas>().enabled = true;
        ended = true;
    }
}
