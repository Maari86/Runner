
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] private Image CurrentHealthBar;

    private void Start()
    {
        TotalHealthBar.fillAmount = PlayerHealth.currentHealth / 10;

    }

    private void Update()
    {
        CurrentHealthBar.fillAmount = PlayerHealth.currentHealth / 10;
    }
}
