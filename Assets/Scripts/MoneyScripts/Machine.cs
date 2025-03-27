using UnityEngine;

public class Machine : MonoBehaviour
{
    public MachineType machineType; // Select from Inspector

    private int GetMachinePrice()
    {
        return (int)machineType; // Convert enum to int price
    }

    public void BuyMachine()
    {
        int cost = GetMachinePrice();

        if (MoneyManager.Instance.SpendMoney(cost))
        {
            Debug.Log(machineType + " purchased for" + cost + Currency.Symbol);
            gameObject.SetActive(true); // Activate the machine after purchase
        }
        else
        {
            Debug.Log("Not enough "+Currency.Symbol+" for " + machineType + "!");
        }
    }
}
