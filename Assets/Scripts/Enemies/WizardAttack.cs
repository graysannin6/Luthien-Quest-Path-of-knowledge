using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WizardAttack : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private int facingDir = -1;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        transform.right = rb.velocity;
    }

    public void SetUpAttack(int dir, Vector3 position)
    {
        if (facingDir != dir)
        {
            transform.Rotate(0, 180, 0);
            facingDir = dir;
        }
        transform.position = position;
        rb.velocity =  new Vector2(10.0f * dir, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInParent<Player>();
        if (player != null)
        {
            rb.velocity = new Vector2(0, 0);
            gameObject.SetActive(false);
            player.updateHealthBar(-5);
            if (player && player.isHealing)
                player.stateMachine.ChangeState(player.idleState);
            if (player && player.Damage(5))
                player.Die();
        }
    }

}
