using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public int Money { get; private set; } = 1000;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            return true;
        }
        return false;
    }

    public void EarnMoney(int amount)
    {
        Money += amount;
    }

    public string GetMoneyDisplay()
    {
        return Currency.Symbol + Money;
    }
}
