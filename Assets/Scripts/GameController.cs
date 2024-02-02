using UnityEngine;

public class GameController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Quit();
        }
    }

    private void Quit()
    {
        Application.Quit();
    }
}
