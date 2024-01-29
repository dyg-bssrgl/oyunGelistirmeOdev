using UnityEngine;

public class Gun : MonoBehaviour
{
    public RectTransform crosshairRectTransform; // UI'deki crosshair'ýn RectTransform'u
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
        Vector3 spawnPoint = GetWorldPositionOfCrosshair(); // Crosshair'ýn dünya koordinatlarýndaki noktasý
        Vector3 direction = Camera.main.transform.forward; // Kamera yönüne göre vektör

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
            return hit.point; // Raycast'in çarptýðý noktayý dön
        }
        else
        {
            return ray.GetPoint(1000); // Eðer bir þeye çarpmazsa, uzak bir noktayý dön
        }
    }

}
