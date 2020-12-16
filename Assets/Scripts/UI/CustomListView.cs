using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomListView<T> : MonoBehaviour where T : class, IFieldList
{
    public FieldSetterList ItemPrefab;
    public Transform ItemsParent;

    protected List<T> Sources = new List<T>();
    private List<FieldSetterList> ListObjects = new List<FieldSetterList>();

    public void UpdateList(IList sources)
    {
        Clear();

        for (int i = 0; i < sources.Count; i++)
        {
            object obj = sources[i];
            T tListItem = Activator.CreateInstance(typeof(T), obj) as T;
            FieldSetterList item = Instantiate(ItemPrefab.gameObject).GetComponent<FieldSetterList>();
            item.SetSourceObject(tListItem);
            item.transform.SetParent(ItemsParent, true);
            item.transform.localScale = Vector3.one;
            item.transform.SetAsLastSibling();
            Sources.Add(tListItem);
            ListObjects.Add(item);
            AfterAddItem(i, item.gameObject, tListItem);
        }

        AfterUpdateList();
    }

    public void Clear()
    {
        foreach (T item in Sources)
        {
            BeforeRemoveItem(item);
        }
        foreach (FieldSetterList listItem in ListObjects)
        {
            Destroy(listItem.gameObject);
        }
        Sources.Clear();
        ListObjects.Clear();
    }

    public void Refresh()
    {
        foreach (FieldSetterList listItem in ListObjects)
        {
            listItem.UpdateValues();
        }
    }

    protected virtual void AfterAddItem(int index, GameObject itemObject, T item)
    { }

    protected virtual void BeforeRemoveItem(T item)
    { }

    protected virtual void AfterUpdateList()
    { }

    private T _selectedItem;
    public T SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            if (typeof(ISelectableItem).IsAssignableFrom(typeof(T)))
            {
                foreach (T item in Sources)
                {
                    ((ISelectableItem)item).IsSelected = item == value;
                }
            }
            AfterSelectionChanged(value);
            Refresh();
        }
    }

    protected virtual void AfterSelectionChanged(T selection)
    { }
}
