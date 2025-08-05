using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping = false;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;


    // Calculer vitesse de mouvement
    void FixedUpdate()
    {
        // Calculer vitesse de mouvement horizontal
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Est ce que ya une demande de saut
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        // Effectuer le mouvement
        MovePlayer(horizontalMovement);

    }

    void MovePlayer(float _horizontalMovement)
    {
        // Calculer vélocité de notre cible ( personnage vers le prochain mouvement)
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}