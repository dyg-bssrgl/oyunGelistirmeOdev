using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Mermiyi olu�turduktan 1 saniye sonra yok et
        Destroy(gameObject, 2f);

        Debug.Log("mermi olu�tu");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("mermi collision");
        if (collision.gameObject.CompareTag("zombie"))
        {
            Debug.Log("Zombie mermi yedi");
            ZombieAttack zombieAttack = collision.gameObject.GetComponent<ZombieAttack>();
            if (zombieAttack != null)
            {
                zombieAttack.ZombieDied(); // ZombieDied metodunu �a��r
            }

            // �arp��ma sonras� mermiyi hemen yok et
            Destroy(gameObject);
        }

        Destroy(gameObject);

    }
}
