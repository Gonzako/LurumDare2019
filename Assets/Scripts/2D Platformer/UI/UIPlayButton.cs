using UnityEngine;

public class UIPlayButton : MonoBehaviour {

    public void StartGame()
    {
        GameManager.Instance.MoveToNextLevel();
        GameManager.Instance.coins = 0;
        GameManager.Instance.Lives = 3;
    }    
}
