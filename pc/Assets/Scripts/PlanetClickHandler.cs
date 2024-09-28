using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetClickHandler : MonoBehaviour
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
