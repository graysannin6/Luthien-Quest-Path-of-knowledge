using UnityEngine;

public class PotionSkillController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }

    public void SetupPotion(Vector2 _dir, float _gravityScale)
    {
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;

        anim.SetBool("Rotate", false);
    }

    private void Update()
    {
        transform.right = rb.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemyComponent) || collision.gameObject.layer == 6)
        {
            //enemyComponent.OnHitByPotion();
            anim.SetBool("Explode", true);
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            Destroy(gameObject, 1.2f);
        }
    }
}
