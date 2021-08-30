using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // приватная переменная создана для создания верхнего предела уничтожения прожектайлов.
    private float topBound = 30.0f;
    // приватная переменная создана для создания нижнего предела уничтожения мобов.
    private float lowerBound = -10.0f;

    void Update()
    {
        // Если позиция по оси z > topBound
        if (transform.position.z > topBound)
        {
            // Прожектайл уничтожается за пределами видимости по заданному значению topBound.
            Destroy(gameObject);
        }
        // или же позиция по оси z < lowerBound
        else if(transform.position.z < lowerBound)
        {
            // выводим надпись в консоле конец игры.
            Debug.Log("GameOver");
            // Мобы уничтожаются за пределами видимости по заданному значению lowerBound.
            Destroy(gameObject);
        }
    }
}
