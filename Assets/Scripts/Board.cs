using System;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private Card cardPrefab;
    
    [SerializeField]
    private Sprite[] sprites;

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => UnityEngine.Random.Range(0, 7)).ToArray();

        GameManager.instance.SetCardCnt(arr.Length);
        int lastCard = UnityEngine.Random.Range(0, arr.Length);

        for (int i = 0; i < arr.Length; i++)
        {
            Card card = Instantiate(cardPrefab, transform);
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            card.Set(arr[i], new Vector2(x, y), sprites[arr[i]], lastCard == i);
        }
    }

    // private Card compareCard = null;
    // private bool CanOpenCard(Card card)
    // {
    //     if(GameManager.instance.time < 30)
    //     {
    //         if(compareCard == null)
    //         {
    //             compareCard = card;
    //             return true;
    //         }
    //         else if(compareCard != card)
    //         {
    //             if(compareCard.index == card.index)
    //             {
    //                 compareCard.DestroyCard();
    //                 card.DestroyCard();
    //             }
    //             else
    //             {
    //                 compareCard.CloseCard();
    //                 card.CloseCard();
    //             }
    //             compareCard = null;
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}