﻿using UnityEngine;
using System.Collections.Generic;

public class CodeCardDatabase : ICardDatabase {

    public List<Card> AllCards { get; set; }

    public CodeCardDatabase()
    {
        AllCards = new List<Card>();
        FillList();
    }

    private void FillList()
    {
        AllCards.Add(new Card() {
            Name = "Blue bird", Health = 2, Attack = 1,
            StaticIDCard = "R_1", DefaultCooldown = 2,
            Quality = Enumerations.EquipmentQuality.Rare,
            CardFlavour = "Blue birds are known for flying higher than normal birds"
        });
        AllCards.Add(new Card() {
            Name = "Red panda", Health = 4, Attack = 2,
            StaticIDCard = "R_2", DefaultCooldown = 4,
            Quality = Enumerations.EquipmentQuality.Legendary,
            CardFlavour = "Rare red pandas have thick fur so they can withstand harsh weater"
        });
        AllCards.Add(new Card() {
            Name = "CUbe", Health = 2, Attack = 2,
            StaticIDCard = "R_3", DefaultCooldown = 3,
            Quality = Enumerations.EquipmentQuality.Common,
            CardFlavour = "No one knows much about CUbes"
        });
        AllCards.Add(new Card() {
            Name = "Black wolf", Health = 2, Attack = 1,
            StaticIDCard = "R_4", DefaultCooldown = 3,
            Quality = Enumerations.EquipmentQuality.Common,
            SpecialAttackID = "SA_1", CardFlavour="Special attack: 'Spread' - Attacks enemy to the right and a enemy to the left" });
    }

    public Card GetNewCard(string staticID)
    {
        foreach (Card c in AllCards)
        {
            if (c.StaticIDCard == staticID)
            {
                return (Card)c.Clone();
            }
        }
        return null;
    }

    public Card GetCard(string staticID)
    {
        foreach (Card c in AllCards)
        {
            if (c.StaticIDCard == staticID)
            {
                return c;
            }
        }
        return null;
    }

    public Card GetRandomCard()
    {
        return (Card)AllCards[Random.Range(0, AllCards.Count)].Clone();
    }

    public List<Card> GetRandomDeck()
    {
        List<Card> outputDeck = new List<Card>(20);

        for (int i = 0; i < 20; i++)
        {
            outputDeck.Add(GetRandomCard());
        }
        return outputDeck;
    }
}
