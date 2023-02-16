using TMPro;
using UnityEngine;

public class PlayerMoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Start()
    {
        PlayerStats.I.Wallet.OnAmountChanged += UpdateUI;
    }

    private void OnDisable()
    {
        PlayerStats.I.Wallet.OnAmountChanged -= UpdateUI;
    }

    private void UpdateUI(float money)
    {
        _moneyText.text = money.ToString("0");
    }
}