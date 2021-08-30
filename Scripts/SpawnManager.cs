using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Создаем массив, который виден в инспекторе для того, чтобы заполнить его префабами мобов.
    public GameObject[] animalPrefabs;
    // создаем приватную переменную, для спауна мобов по оси x.
    private float spawnRangeX = 16.0f;
    // создаем приватную переменную, для спауна мобов по оси z.
    private float spawnPosZ = 20.0f;
    // создаем переменную для спавна мобов с определенной задержкой.
    private float startDelay = 2f;
    // создаем переменную для спавна мобов с интервалом времени.
    private float spawnInterval = 4.5f;

    void Start()
    {
        // создаем метод InvokeRepeating, для того, чтобы мобы спавнились автоматически каждые 4,5 секунды, со стартовой задержкой в 2 секунды.
        // вызываем метод SpawnRandomAnimal, так как именно его используем для случайного спавна мобов.
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // создаем кастомную функцию (метод) SpawnRandomAnimal(), чтобы можно было много раз использовать SpawnRandomAnimal, без переписывания полного кода. 
    void SpawnRandomAnimal()
    {
        // создаем переменную animalIndex, в этом методе, так как только тут будем ее использовать. 
        // используем класс Random.Range для того, чтобы мобы спавнились со случайностью от 0 до длины массива мобов т.е. 3.
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // Используем Random.Range, чтобы мобы спавнились в разных точках от -16 до 16 по оси x.
        // Используем Vector3 spawnPos для того, чтобы занести в формулу координаты спавна мобов.
        // Спавн мобов по осям y и z остаются неизменными, по оси z задано значение 20f
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // Создаем копии animalPrefabs по номеру индекса массива, поворот мобов остается по умолчанию, так как двигаются только в одну сторону.
        // Используем spawnPos в которой занесены кординаты случайного спавна мобов по оси x, по осям y,z использыем заданные значения.
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
