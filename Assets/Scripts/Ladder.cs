using UnityEngine;

public class Ladder : MonoBehaviour
{

    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D collider;


    public void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        if (playerMovement.isClimbing = true && Input.GetKeyDown(KeyCode.E))
        {
            // descendre de l'échelle
            playerMovement.isClimbing = false;
            collider.isTrigger = false;
            Debug.Log("descente de l'échelle");
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            collider.isTrigger = true;
        }
    }

    // ontrigger = lire du code quand l'objet entre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }

    }

    // ontrigger = lire du code quand l'objet sort
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false; 
            collider.isTrigger = false;   
        }
    }
}
 