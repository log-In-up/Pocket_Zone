using Inventory;
using MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class DropCollector : MonoBehaviour
    {
        #region Fields
        private InventoryController _inventoryController = null;
        #endregion

        #region MonoBehaviour API
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out DropDataHolder dropDataHolder))
            {
                _inventoryController.AddItem(dropDataHolder);
                Destroy(dropDataHolder.gameObject);
            }
        }
        #endregion

        #region Public Methods
        internal void Init(InventoryController inventoryController)
        {
            _inventoryController = inventoryController;
        }
        #endregion
    }
}