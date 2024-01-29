using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private Animator animator;
    public float damageInterval = 1.0f;
    public float damage = 1.0f;
    private float lastDamageTime;
    private Transform playerTransform;
    private bool running = false;
    private bool attacking = false;
    private bool attackPosition = false;
    public HealthBar playerHealthBar;
    private bool died = false;
    public UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        GameObject player = GameObject.FindWithTag("Player"); // "Player" tag'ine sahip objeyi bul
        if (player != null)
        {
            playerHealthBar = player.GetComponent<HealthBar>(); // Player üzerindeki HealthBar scriptini al
        }
    }

    /*public void OnDeath()
    {

    }*/

    public void ZombieDied()
    {
        if (died)
            return;

        foreach (var parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(parameter.name);
            }
        }

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(1); // Skoru 1 puan artýr
        }

        died = true;
        animator.SetTrigger("DieZombie");
        Invoke("DieDestroy", 5.0f);
    }

    public void DieDestroy()
    {
        Destroy(gameObject);
    }

    public void CollisionDetected(ZombieChild childScript, Collider other)
    {
        if (!died && !attackPosition && !running && !attacking && childScript.gameObject.name == "Z_Head")
        {
            running = true;
            Debug.Log("Run");
            animator.ResetTrigger("NotRunToPlayer");
            animator.SetTrigger("RunToPlayer");
        }

        if(!died && childScript.gameObject.name == "Z_BodyTop")
        {
            attackPosition = true;
            attacking = true;
            running = false;
            Debug.Log("Attack");
            animator.ResetTrigger("NotAttack");
            animator.SetTrigger("Attack");
            lastDamageTime = Time.time;
        }
    }

    public void CollisionStayed(ZombieChild childScript, Collider other) {
        playerTransform = other.transform;
        
        if(!died && childScript.gameObject.name == "Z_Head" && !attackPosition)
            agent.SetDestination(playerTransform.position);

        if (!died && !attackPosition && !running && !attacking && childScript.gameObject.name == "Z_Head")
        {
            running = true;
            Debug.Log("Run");
            animator.ResetTrigger("NotRunToPlayer");
            animator.SetTrigger("RunToPlayer");
        }

        if (!died && childScript.gameObject.name == "Z_BodyTop")
        {
            attackPosition = true;
            running = false;
            attacking = true;
            Debug.Log("Attack");
            animator.ResetTrigger("NotAttack");
            animator.SetTrigger("Attack");

            if (Time.time > lastDamageTime + damageInterval)
            {
                if (playerHealthBar != null)
                {
                    playerHealthBar.TakeDamage(damage);
                }

                lastDamageTime = Time.time;
            }
        }
    }

    public void CollisionExited(ZombieChild childScript, Collider other) {
        if (!died && childScript.gameObject.name == "Z_Head")
        {
            running = false;
            playerTransform = null;
            animator.ResetTrigger("RunToPlayer");
            animator.SetTrigger("NotRunToPlayer");
        }

        if (!died && childScript.gameObject.name == "Z_BodyTop")
        {
            attackPosition = false;
            attacking = false;
            animator.ResetTrigger("Attack");
            animator.SetTrigger("NotAttack");
        }
    }

    void Update()
    {
        if (!died && playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);

            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
