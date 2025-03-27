using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public Machine machine;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(machine.BuyMachine);
    }
}
