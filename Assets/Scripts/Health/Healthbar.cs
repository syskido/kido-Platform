using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHeakth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHeakth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHeakth.currentHealth / 10;
    }
}
