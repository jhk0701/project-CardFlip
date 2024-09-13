using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private Card cardPrefab;
    
    [SerializeField]
    private Sprite[] sprites;
    
    [Header("Card")]
    public int cardCount = 16;
    public Card selectedCard;
    public Card lockedCard; // last card


    void Start()
    {
        if(!GameManager.instance.board)
            GameManager.instance.board = this;

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => UnityEngine.Random.Range(0, 7)).ToArray();

        SetCardCnt(arr.Length);
        int lastCard = -1; 
        
        if(ManagerGlobal.instance.curPlayingStage > 0)
            lastCard = Random.Range(0, arr.Length);

        for (int i = 0; i < arr.Length; i++)
        {
            Card card = Instantiate(cardPrefab, transform);
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            card.Set(arr[i], new Vector2(x, y), sprites[arr[i]], lastCard == i);
        }
    }

    
    void SetCardCnt(int cnt){
        cardCount = cnt;

        if(cardCount.Equals(0)){
            // win
            GameManager.instance.GameOver(true);
        }
        else if(cardCount.Equals(2)){
            lockedCard?.Unlock();
        }
    }

    public void SelectCard(Card c){
        
        if(selectedCard == null)
        {
            selectedCard = c;
            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Touch);

            return;
        }

        if(c.index.Equals(selectedCard.index)){
            // match
            PlayEffect(selectedCard, "Success");
            PlayEffect(c, "Success");
            selectedCard.DestroyCard();
            c.DestroyCard();

            SetCardCnt(cardCount - 2);
            
            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Success);

            // bonus
            GameManager.instance.AddTime(true);
        }
        else{
            // not match
            selectedCard.anim.SetTrigger("failTrigger");
            c.anim.SetTrigger("failTrigger");
            
            selectedCard.CloseCard(0.8f);
            c.CloseCard(0.8f);

            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Fail);

            //penalty
            GameManager.instance.AddTime(false);
        }

        selectedCard = null;
    }

    void PlayEffect(Card card, string Success)
    {
        GameObject SuccessEffect = Instantiate(Resources.Load(Success), card.transform.position, Quaternion.identity) as GameObject;
        Destroy(SuccessEffect, 1f);
    }

}