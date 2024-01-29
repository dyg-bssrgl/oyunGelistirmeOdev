using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Mermiyi oluþturduktan 1 saniye sonra yok et
        Destroy(gameObject, 2f);

        Debug.Log("mermi oluþtu");
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
                zombieAttack.ZombieDied(); // ZombieDied metodunu çaðýr
            }

            // Çarpýþma sonrasý mermiyi hemen yok et
            Destroy(gameObject);
        }

        Destroy(gameObject);

    }
}
