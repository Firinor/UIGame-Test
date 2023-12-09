using UnityEngine;
using UnityEngine.Purchasing;

public class Shop : MonoBehaviour
{
    public void OnPurchaiceComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "500tickets":
                AddTickets(500);
                break;
            case "1200tickets":
                AddTickets(1200);
                break;
            default:
                throw new System.Exception("Unknown purchase ID!");
        }
    }

    private void AddTickets(int value)
    {
        Player.instance.AddTickets(value);
    }
}
