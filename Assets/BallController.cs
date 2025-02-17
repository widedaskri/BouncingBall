using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;       // Vitesse de déplacement horizontal
    public float jumpForce = 8f;   // Force du saut
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        

        // Déplacement avec l'accéléromètre
        Vector3 movement = new Vector3(Input.acceleration.x, 0, 0) * speed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, 0);

        // Saut en touchant l'écran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // Empêche de sauter plusieurs fois en l'air
        }
    }

    // Vérification du contact avec le sol
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
