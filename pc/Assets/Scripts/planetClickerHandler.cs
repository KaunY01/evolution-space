using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planetClickerHandler : MonoBehaviour
{

    private void OnMouseDown()
    {
        // ������ �������� ����� �������� �����
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene("Earth"); // �������� "Earth" �� ��� ����� �����
    }
}
