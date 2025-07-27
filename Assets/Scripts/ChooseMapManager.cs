using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMapManager : MonoBehaviour
{
    public void Map1()
    {
        SceneManager.LoadScene("Game1");
    }
    public void Map2()
    {   
        SceneManager.LoadScene("Game2");
    }
    public void Map3()
    {
        SceneManager.LoadScene("Game3");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
