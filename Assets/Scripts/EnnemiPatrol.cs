using UnityEngine;

public class EnnemiPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoint;

    public SpriteRenderer graphics;
    private Transform target;
    private int desPoint = 0;

    void Start()
    {
        target = waypoint[0];
    }


    void Update()
    {
        // prend la position de la cible moins la position de l'ennemie pour savoir ou aller
        Vector3 dir = target.position - transform.position;

        // Systéme de déplacement ( une seule fois ) 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // SI l'ennemi est quasiment arrivé a sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            desPoint = (desPoint + 1) % waypoint.Length;
            target = waypoint[desPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
}
