using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkinsList : CustomListView<SkinObjectFieldList>
{
    private void Start()
    {
        UpdateList(SkinsController.Instance.BallSkins);
        SelectedItem = Sources.FirstOrDefault(c => c.SourceObject.SkinId == SkinsController.SelectedSkinId);
    }

    protected override void AfterAddItem(int index, GameObject itemObject, SkinObjectFieldList item)
    {
        base.AfterAddItem(index, itemObject, item);
        item.onButtonClick += Item_onButtonClick;
    }

    protected override void BeforeRemoveItem(SkinObjectFieldList item)
    {
        base.BeforeRemoveItem(item);
        item.onButtonClick -= Item_onButtonClick;
    }

    private void Item_onButtonClick(SkinObjectFieldList obj)
    {
        SelectedItem = obj;
    }

    protected override void AfterSelectionChanged(SkinObjectFieldList selection)
    {
        base.AfterSelectionChanged(selection);
        if (selection != null)
        {
            SkinsController.SelectedSkinId = selection.SourceObject.SkinId;
        }
    }
}
