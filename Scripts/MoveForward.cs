using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // переменная для скорости передвижения прожектайла видна в инспекторе.
    public float speed = 40.0f;

    void Update()
    {
        // Создаем направление и скорость движения прожектайла одинаковой для всех пк.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
