using DialogueManager;
using PlayerManagement;
using UnityEngine;

public class TombEvent : MonoBehaviour
{
    [SerializeField] private FindEventId TombId;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsPlayer(other))
        {
            return;
        }
        PlayerCoreManager.Instance.TombEventToggle(true, TombId);
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!IsPlayer(other))
        {
            return;
        }
        PlayerCoreManager.Instance.TombEventToggle(false, 0);

    }

    private bool IsPlayer(Collider2D col)
    {
        return col.TryGetComponent<CharacterMovementController>(out _);
    }
}
