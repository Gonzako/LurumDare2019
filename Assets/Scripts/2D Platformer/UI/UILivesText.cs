using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        tmproText.text = GameManager.Instance.Lives.ToString();
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        tmproText.text = livesRemaining.ToString();
    }
}
