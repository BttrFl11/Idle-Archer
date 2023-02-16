using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthImage;

    private void OnEnable()
    {
        Tower.OnHealthChanged += UpdateUI;
    }

    private void OnDisable()
    {
        Tower.OnHealthChanged -= UpdateUI;
    }

    private void UpdateUI(float currentHealth, float maxHealth)
    {
        _healthText.text = $"{currentHealth} / {maxHealth}";
        _healthImage.fillAmount = currentHealth / maxHealth;
    }
}
