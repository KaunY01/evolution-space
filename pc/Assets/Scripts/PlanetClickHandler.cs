using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Просто вызываем метод загрузки сцены
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene("Earth"); // Замените "Earth" на имя вашей сцены
    }
}
