using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    float mainSpeed = 15.0f; // регулярная скорость движения камеры
    float shiftAdd = 30.0f; // дополнительное ускорение при удержании Shift
    float maxShift = 50.0f; // максимальная скорость при удержании Shift
    float camSens = 0.20f; // чувствительность камеры при вращении мышью
    private Vector3 lastMouse = new Vector3(255, 255, 255); // начальная позиция мыши
    private float totalRun = 1.0f; // множитель скорости при удержании Shift

    public float collisionRadius = 1.0f; // Радиус для проверки коллизий
    public LayerMask collisionMask; // Слой для проверки столкновений

    void Update()
    {
        // Mouse camera angle - only when right mouse button is held
        if (Input.GetMouseButton(1)) // 1 - правая кнопка мыши
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
        }
        lastMouse = Input.mousePosition;

        // Команды клавиатуры
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position + transform.TransformDirection(p);

        // Проверка столкновений перед перемещением
        if (!Physics.CheckSphere(newPosition, collisionRadius, collisionMask))
        {
            transform.Translate(p);
        }
    }

    private Vector3 GetBaseInput()
    {
        // Возвращает базовые значения, если они не равны 0
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
