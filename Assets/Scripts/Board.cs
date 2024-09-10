using System;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private Card cardPrefab;

    [SerializeField]
    private Sprite junghwan1;
    [SerializeField]
    private Sprite junghwan2;
    [SerializeField]
    private Sprite younghan1;
    [SerializeField]
    private Sprite younghan2;
    [SerializeField]
    private Sprite chamsol1;
    [SerializeField]
    private Sprite chamsol2;
    [SerializeField]
    private Sprite jiyoon1;
    [SerializeField]
    private Sprite jiyoon2;

    private Card compareCard = null;

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => UnityEngine.Random.Range(0, 7)).ToArray();
        for (int i = 0; i < 16; i++)
        {
            Card card = Instantiate(cardPrefab, transform);
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            switch(arr[i])
            {
                case 0:
                    card.Set(0, new Vector2(x, y), junghwan1, CanOpenCard);
                    break;
                case 1:
                    card.Set(0, new Vector2(x, y), junghwan2, CanOpenCard);
                    break;
                case 2:
                    card.Set(0, new Vector2(x, y), younghan1, CanOpenCard);
                    break;
                case 3:
                    card.Set(0, new Vector2(x, y), younghan2, CanOpenCard);
                    break;
                case 4:
                    card.Set(0, new Vector2(x, y), chamsol1, CanOpenCard);
                    break;
                case 5:
                    card.Set(0, new Vector2(x, y), chamsol2, CanOpenCard);
                    break;
                case 6:
                    card.Set(0, new Vector2(x, y), jiyoon1, CanOpenCard);
                    break;
                case 7:
                    card.Set(0, new Vector2(x, y), jiyoon2, CanOpenCard);
                    break;
            }
        }
    }

    private bool CanOpenCard(Card card)
    {
        if(GameManager.Instance.time < 30)
        {
            if(compareCard == null)
            {
                compareCard = card;
                return true;
            }
            else if(compareCard != card)
            {
                if(compareCard.index == card.index)
                {
                    compareCard.DestroyCard();
                    card.DestroyCard();
                }
                else
                {
                    compareCard.CloseCard();
                    card.CloseCard();
                }
                compareCard = null;
                return true;
            }
        }
        return false;
    }
}