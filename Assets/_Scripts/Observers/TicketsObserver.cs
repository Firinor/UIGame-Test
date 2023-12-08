using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TicketsObserver : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        player.OnTicketChange += OnTicketsChanged;
        OnTicketsChanged(player.GetTickets());
    }

    private void OnTicketsChanged(int newValue)
    {
        text.text = newValue.ToString();
    }

    private void OnDestroy()
    {
        player.OnTicketChange -= OnTicketsChanged;
    }
}
