using System;
using System.Collections.Generic;
using ShopManagement;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace UI
{
    public class ItemOverviewController : MonoBehaviour
    {
        [SerializeField] private Image mItemIcon;
        [SerializeField] private TMP_Text mItemName;
        [SerializeField] private TMP_Text mItemCost;
        [SerializeField] private SpriteAtlas mSpriteAtlas;
        
        private IShopItem _mItemShopData;
        private Dictionary<string, Sprite> _mLoadedSprites = new Dictionary<string, Sprite>();

        public void InitializeData(IShopItem itemData)
        {
            _mItemShopData = itemData;
            mItemName.text = _mItemShopData.Item.Name;
            mItemCost.text = _mItemShopData.Item.BuyPrice.ToString();
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
    }
}
