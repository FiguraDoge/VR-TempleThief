﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory is found");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space;
    public List<Item> items = new List<Item>();
    public Item initialKey;
    private bool addKey;

    void Start()
    {
        space = 20;
        addKey = false;
    }

    void Update()
    {
        if (!addKey)
        {
            items.Add(initialKey);
            if (onItemChangedCallback != null)
            {
                Debug.Log("adding initialKey");
                onItemChangedCallback.Invoke();
            }
            addKey = true;
        }
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

}
