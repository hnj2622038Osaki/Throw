
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalOssan = 5;
    private int killed = 0;

    public void AddKill()
    {
        killed++;

        if (killed >= totalOssan)
        {
            ClearGame();
        }
    }

    void ClearGame()
    {
        if (killed == totalOssan)
        { 
            SceneManager.LoadScene("ClearScene"); 
        }
    }
}

