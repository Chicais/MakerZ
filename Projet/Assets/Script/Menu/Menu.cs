
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnClickMulti()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickSolo()
    {
        SceneManager.LoadScene(3);
    }

    public void OnClickEditeur()
    {
        SceneManager.LoadScene(4);
    }
}

