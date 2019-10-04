using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndButton : MonoBehaviour {
    
    public void EndGame()
    {
        GameManager.Instance.currentLevelIndex = 0;
        SceneManager.LoadScene(0);
    }
}
