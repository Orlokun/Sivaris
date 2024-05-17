using PlayerManagement;
using TMPro;
using UnityEngine;

public interface IBaseInfoCanvas
{
    void UpdateMoneyText();
}

public class BaseInfoCanvas : MonoBehaviour, IBaseInfoCanvas
{
    [SerializeField] private TMP_Text currencyAmount;
    private IPlayerMoney _mPlayerMoneySource;
    private void Start()
    {
        UpdateMoneyText();
    }
    public void UpdateMoneyText()
    {
        _mPlayerMoneySource = PlayerCoreManager.Instance.PlayerData;
        currencyAmount.text = _mPlayerMoneySource.Currency.ToString();
    }
}
