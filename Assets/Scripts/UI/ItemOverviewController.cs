using System;
using System.Collections.Generic;
using ShopManagement;
using ShopManagement.ItemsInShop;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace UI
{
    public class ItemOverviewController : MonoBehaviour
    {
        [SerializeField] private Image mItemIcon;
        [SerializeField] private TMP_Text mItemName;
        [SerializeField] private TMP_Text mItemCost;
        [SerializeField] private Button mChooseItem;

        [SerializeField] private TMP_Text mQuantity;
        //Should be in a generalized place. But no time :D
        [SerializeField] private SpriteAtlas mSpriteAtlas;

        private IItemSelectable _mShopManagement;
        private IShopItem _mItemShopData;
        private Dictionary<string, Sprite> _mLoadedSprites = new Dictionary<string, Sprite>();

        private void Awake()
        {
            mChooseItem.onClick.AddListener(PreSelectItem);
        }

        private void PreSelectItem()
        {
            var chosenSprite = GetSprite(_mItemShopData.Item.IconPath);
            _mShopManagement.SelectItem(_mItemShopData.Item, chosenSprite);
        }

        public void InitializeData(IItemSelectable shopUI, IShopItem itemData)
        {
            _mShopManagement = shopUI;
            _mItemShopData = itemData;
            mItemName.text = _mItemShopData.Item.Name;
            mItemCost.text = _mItemShopData.Item.BuyPrice.ToString();
            mQuantity.text = "x" + _mItemShopData.Quantity;
            LoadSpriteToImage(mItemIcon, _mItemShopData.Item.IconPath);
        }

        private void LoadSpriteToImage(Image iconImageHolder, string spriteKey)
        {
            try
            {
                var spriteImage = mSpriteAtlas.GetSprite(spriteKey);
                iconImageHolder.sprite = spriteImage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Sprite GetSprite(string spriteKey)
        {
            try
            {
                var spriteImage = mSpriteAtlas.GetSprite(spriteKey);
                return spriteImage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
