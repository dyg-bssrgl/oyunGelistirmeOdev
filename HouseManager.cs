using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public GameObject zombieBodyTop; // Zombinin "Z_BodyTop" GameObject'i

    private void Start()
    {
        SetupChildren();
    }

    private void SetupChildren()
    {
        foreach (Transform child in transform)
        {
            ChildCollisionDetector detector = child.gameObject.AddComponent<ChildCollisionDetector>();
            detector.zombieBodyTop = zombieBodyTop; // Zombi body referansýný ata
        }
    }
}

public class ChildCollisionDetector : MonoBehaviour
{
    public GameObject zombieBodyTop; // Zombinin "Z_BodyTop" referansý

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == zombieBodyTop)
        {
            Destroy(this.gameObject); // Eðer Z_BodyTop ile çarpýþýrsa, bu GameObject'i yok et
        }
    }
}
