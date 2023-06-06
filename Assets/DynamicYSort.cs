using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicYSort : MonoBehaviour
{
    private int baseSortingOrder;
    [SerializeField] private SortableSprite[] sortableSprites;

    void Update()
    {
        baseSortingOrder = transform.GetSortingOrder();
        foreach (var sortableSprite in sortableSprites){
            sortableSprite.spriteRenderer.sortingOrder = baseSortingOrder + sortableSprite.relativeOrder;
        }
    }

    [Serializable]
    public struct SortableSprite{
        public SpriteRenderer spriteRenderer;
        public int relativeOrder;
    }
}
