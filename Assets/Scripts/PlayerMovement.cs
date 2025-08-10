using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;


    private bool isJumping;
    private bool isGrounded;
    
    [HideInInspector]
    public bool isClimbing;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;



    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    void Update()
    {
        // Calculer vitesse de mouvement horizontal
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        // Calculer vitesse de mouvement vertical
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        // Est ce que ya une demande de saut
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }

        Flip(rb.linearVelocity.x);

        // envoie la vitesse horizontal
        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", rb.linearVelocity.x);
        animator.SetBool("isClimbing", isClimbing);
    }

       
        void FixedUpdate()
         {
        // il crée une boite de collision
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        // Effectuer le mouvement
        MovePlayer(horizontalMovement, verticalMovement);
        }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {
            // Calculer vélocité de notre cible ( personnage vers le prochain mouvement)
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            //déplacement vertical
            Vector3 targetVelocity = new Vector2(0 , _verticalMovement);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);
        }

    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f) 
        {
            spriteRenderer.flipX = false;
        } 
        else if(_velocity < -0.1f) 
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnDrawGizmos()
    {
        // Dessine le cercle de vérification du sol
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}