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
            detector.zombieBodyTop = zombieBodyTop; // Zombi body referans�n� ata
        }
    }
}

public class ChildCollisionDetector : MonoBehaviour
{
    public GameObject zombieBodyTop; // Zombinin "Z_BodyTop" referans�

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == zombieBodyTop)
        {
            Destroy(this.gameObject); // E�er Z_BodyTop ile �arp���rsa, bu GameObject'i yok et
        }
    }
}
