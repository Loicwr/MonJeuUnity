using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Transform playerSpawn;

    public void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
