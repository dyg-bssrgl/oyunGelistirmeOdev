using UnityEngine;

public class Gun : MonoBehaviour
{
    public RectTransform crosshairRectTransform; // UI'deki crosshair'�n RectTransform'u
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 spawnPoint = GetWorldPositionOfCrosshair(); // Crosshair'�n d�nya koordinatlar�ndaki noktas�
        Vector3 direction = Camera.main.transform.forward; // Kamera y�n�ne g�re vekt�r

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direction * bulletSpeed;
    }



    Vector3 GetWorldPositionOfCrosshair()
    {
        Ray ray = Camera.main.ScreenPointToRay(crosshairRectTransform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000)) // Buradaki 1000, raycast mesafesi
        {
            return hit.point; // Raycast'in �arpt��� noktay� d�n
        }
        else
        {
            return ray.GetPoint(1000); // E�er bir �eye �arpmazsa, uzak bir noktay� d�n
        }
    }

}
