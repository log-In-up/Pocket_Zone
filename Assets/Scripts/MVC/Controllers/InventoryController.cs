using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public sealed class InventoryController
    {
        #region Fields
        private readonly InventoryModel _inventoryModel;
        #endregion

        public InventoryController(InventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
        }
    }
}