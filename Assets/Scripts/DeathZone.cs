using UnityEngine;
using UnityEngine.Rendering;

public class DeathZone : MonoBehaviour
{

    private Transform playerSpawn;

    public void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = playerSpawn.position;
        }
    }
}
 