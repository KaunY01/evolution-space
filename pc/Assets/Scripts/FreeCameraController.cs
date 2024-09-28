using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    float mainSpeed = 15.0f; // ���������� �������� �������� ������
    float shiftAdd = 30.0f; // �������������� ��������� ��� ��������� Shift
    float maxShift = 50.0f; // ������������ �������� ��� ��������� Shift
    float camSens = 0.20f; // ���������������� ������ ��� �������� �����
    private Vector3 lastMouse = new Vector3(255, 255, 255); // ��������� ������� ����
    private float totalRun = 1.0f; // ��������� �������� ��� ��������� Shift

    public float collisionRadius = 1.0f; // ������ ��� �������� ��������
    public LayerMask collisionMask; // ���� ��� �������� ������������

    void Update()
    {
        // Mouse camera angle - only when right mouse button is held
        if (Input.GetMouseButton(1)) // 1 - ������ ������ ����
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
        }
        lastMouse = Input.mousePosition;

        // ������� ����������
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

        // �������� ������������ ����� ������������
        if (!Physics.CheckSphere(newPosition, collisionRadius, collisionMask))
        {
            transform.Translate(p);
        }
    }

    private Vector3 GetBaseInput()
    {
        // ���������� ������� ��������, ���� ��� �� ����� 0
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
