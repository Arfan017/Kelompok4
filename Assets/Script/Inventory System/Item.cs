using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject worldObject;
    [SerializeField] GameObject UIObject;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Image image;
    [SerializeField] bool isInInventory;
    [SerializeField] UiItem uiItem;

    Inventory inventory;



    public bool IsInInventory
    {
        get => isInInventory; 
        set
        {
            isInInventory = value;
            worldObject.SetActive(!isInInventory);
            UIObject.SetActive(isInInventory);
        }
    }

    public Image Image { get => image; }
    public UiItem UiItem { get => uiItem; }

    public void Awake(){
        IsInInventory = isInInventory;
    }

    public void Act(Interactor interactor)
    {
        var InventoryComponent = interactor.GetComponent<InventoryComponent>();
        inventory = InventoryComponent.Inventory;
        inventory.Add(this);
        IsInInventory = true;
    }

    public void Focused(Interactor interactor)
    {
        spriteRenderer.DOColor(Color.grey, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void UnFocused(Interactor interactor)
    {
        spriteRenderer.DOKill();
        spriteRenderer.color = Color.white;
    }

    public void Use(){
        inventory.Remove(this);
        Destroy(this.gameObject);
    }

    public void Drop()
    {
        this.transform.SetParent(null);
        inventory.Remove(this);
        IsInInventory = false;   
        var pos = this.transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        pos.z = 0;
        this.transform.position = pos;
    }
}
