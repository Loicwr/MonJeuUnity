using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    // sert a garder ce qu'on a besoin pour tout les niveaux
    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }


}
