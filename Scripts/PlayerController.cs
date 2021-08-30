using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // переменная для движения игрока влево и вправо.
    private float horizontalInput;
    // переменная для скорости передвижения персонажа, видна в инспекторе.
    public float speed = 10.0f;
    // переменная для ограничения движения персонажа по оси x, видна в инспекторе.
    public float xRange = 15.0f;

    // public GameObject это класс или тип с именем projectilePrefab и он виден в инспекторе.
    // помещаем префаб прожектайла в GameObject projectilePrefab (В инспекторе Player).
    public GameObject projectilePrefab;

    // Используем метод FixedUpdate(), за место Update() чтобы персонаж не колотился о стены.
    void FixedUpdate()
    {
        // Если позиция игрока по оси x < - 15
        if (transform.position.x < -xRange)
        {
            // То игрок не сможет двигаться дальше влево если значение будет < -15, значение по y и z остаются по умолчанию.
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        // Если позиция игрока по оси x > 15
        if (transform.position.x > xRange)
        {
            // То игрок не сможет двигаться дальше вправо если значение будет > 10, значение по y и z остаются по умолчанию. 
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Input.GetAxis("Horizontal"); получаем доступ к менеджеру в unity Project settings - Input Manager - Axes - Horizontal - Name (Horizontal)
        // Теперь видим в инспекторе что значения движения меняются от -1 до 1, но персонаж не двигается.
        horizontalInput = Input.GetAxis("Horizontal");
        // Персонаж может перемещаться влево и вправо с указанной скоростью на любом пк.
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Если нажимаем пробел
        // GetKeyDown используется один прожектайл за одно нажатие, GetKey используется режим пулемета при 1 нажатии.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate(projectilePrefab создаем копии существующего projectilePrefab.
            // transform.position нужен для того чтобы клоны прожектайлов появлялись в нужной позиции у Player.
            // projectilePrefab.transform.rotation поворот прожектайла остается по умолчанию, так как двигается только в одну сторону.
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
