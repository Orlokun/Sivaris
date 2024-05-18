using System.Collections;
using DialogueManager;
using PlayerManagement;
using UnityEngine;

public class TombEvent : MonoBehaviour
{
    [SerializeField] private FindEventId TombId;
    [SerializeField] private GameObject FbButton;

    private Coroutine _mFbCoroutine;
    private void Start()
    {
        FbButton.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsPlayer(other))
        {
            return;
        }
        _mFbCoroutine = StartCoroutine(WaitForFeedback());
        PlayerCoreManager.Instance.PlayerSwitchAvailableEventState(true, TombId);
    }

    private IEnumerator WaitForFeedback()
    {
        yield return new WaitForSeconds(1);
        FbButton.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!IsPlayer(other))
        {
            return;
        }
        PlayerCoreManager.Instance.PlayerSwitchAvailableEventState(false, 0);
        FbButton.SetActive(false);
        if (_mFbCoroutine != null)
        {
            StopCoroutine(_mFbCoroutine);
            _mFbCoroutine = null;
        }
    }

    private bool IsPlayer(Collider2D col)
    {
        return col.TryGetComponent<CharacterMovementController>(out _);
    }
}
