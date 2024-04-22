using UnityEngine;
using UnityEngine.SceneManagement;

public class startscene : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
