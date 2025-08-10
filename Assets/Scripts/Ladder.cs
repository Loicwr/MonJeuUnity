using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{

    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D Topcollider;

    public Text interactUI;


    public void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    public void Update()
    {
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            // descendre de l'échelle
            playerMovement.isClimbing = false;
            Topcollider.isTrigger = false;
            Debug.Log("descente de l'échelle");
            return;
            
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            Topcollider.isTrigger = true;
        }
    }

    // ontrigger = lire du code quand l'objet entre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
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
            Topcollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
 