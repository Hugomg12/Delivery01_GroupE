
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float velocidadCaminar = 5f;
    public float fuerzaSalto = 5f;
    public GameObject GroundCheck;

    private bool enSuelo;
    private float TamañoGround = 0.4f;
    public LayerMask capaSuelo;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    private Rigidbody2D rb;
    private bool puedeSaltar = true;

    private int saltosRestantes;
    public int maxSaltos = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosRestantes = maxSaltos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {

            fuerzaSalto = fuerzaSalto * 2;
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Ending");
        }
    }


    private void Update()
    {
        enSuelo = Physics2D.OverlapCircle(GroundCheck.transform.position, TamañoGround, capaSuelo);

        float movimiento = Input.GetAxis("Horizontal");
        bool correr = Input.GetKey(KeyCode.LeftShift);

        rb.linearVelocity = new Vector2(movimiento * velocidadCaminar, rb.linearVelocity.y);

        if (movimiento > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (movimiento < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if (enSuelo)
        {
            coyoteTimeCounter = coyoteTime;
            saltosRestantes = maxSaltos;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (coyoteTimeCounter > 0 || saltosRestantes > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            saltosRestantes--;
            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        if (enSuelo)
        {
            puedeSaltar = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {

            SceneManager.LoadScene("Title");
        }


    }
}



