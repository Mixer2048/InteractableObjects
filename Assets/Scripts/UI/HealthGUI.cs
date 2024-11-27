using UnityEngine;
using UnityEngine.UI;

public class HealthGUI : MonoBehaviour
{
    [SerializeField] private Image leftHealthImage;
    [SerializeField] private Image rightHealthImage;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        float fillAmount = (float)currentHealth / (float)maxHealth;

        leftHealthImage.fillAmount = fillAmount;
        rightHealthImage.fillAmount = fillAmount;
    }
}
