using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public void Awake()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            player.transform.position = transform.position;
        }
    }
}
