using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float m_spacing = 8.0f;

    List<Card> m_cards = new List<Card>();

    public void AddCard(Card card, bool isFaceUp)
    {
        card.transform.SetParent(transform, false);
        card.transform.localPosition = new Vector3(m_spacing * m_cards.Count, 0.0f, 0.0f);
        card.SetFaceUp(isFaceUp);
        m_cards.Add(card);
    }

    public int Score()
    {
        // TODO calculate the score
        int sum = 0;
        for (int i = 0; i < m_cards.Count; i++){
            sum += Card.s_value[m_cards[i].m_rank];
            string suit = Card.s_suitName[(int)m_cards[i].m_suit];

            if (suit == "Club"){
                sum++;
            }
            else if (suit == "Diamond"){
                sum+=2;
            }
            else if (suit == "Heart"){
                sum--;
            }
            else if (suit == "Spade"){
                sum-=2;
            }

        }
        return sum;
    }

    public int NumCards()
    {
        return m_cards.Count;
    }

    public void RevealAll()
    {
        foreach (Card card in m_cards)
        {
            card.SetFaceUp(true);
        }
    }

    public void Clear()
    {
        foreach (Card card in m_cards)
        {
            Destroy(card.gameObject);
        }
        m_cards.Clear();
    }
}
