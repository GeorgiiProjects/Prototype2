using UnityEngine;

public class DetectColissions : MonoBehaviour
{
    // метод позволяет взаимодействовать коллайдерам мобов и прожектайлов друг с другом
    private void OnTriggerEnter(Collider other)
    {
        // моб уничтожает прожектайл.
        Destroy(gameObject);
        // моб так же уничтожается при взаимодействии с прожектайлом.
        Destroy(other.gameObject);
    }
}
