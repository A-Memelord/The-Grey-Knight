using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public string Name;
    public int ID;
    public GameObject UIVariant;
    public virtual void UseItem()
    {
        Debug.Log("Using item: " + Name);
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right Click");
            FindFirstObjectByType<ItemUse>().UseItem(transform.parent.GetSiblingIndex());
        }


    }
}
