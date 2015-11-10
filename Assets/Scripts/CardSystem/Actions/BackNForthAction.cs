﻿using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.CardSystem.Actions
{
    class BackNForthAction : Action
    {
        public override void useCard(Character actor)
        {
            Weapons.Projectiles.BackNForth temp = MonoBehaviour.Instantiate(prefab).GetComponent<Weapons.Projectiles.BackNForth>();
            temp.Damage = damage;
            temp.Owner = actor.gameObject;
            Util.AddElement.AddElementByEnum(temp.gameObject, element, true);
            if (actor.Direction == Util.Enums.Direction.Left)
            {
                temp.Direction = Util.Enums.Direction.Left;
                temp.transform.position = actor.CurrentNode.Left.transform.position;
                temp.CurrentNode = actor.CurrentNode.Left;
            }

            if (actor.Direction == Util.Enums.Direction.Right)
            {
                temp.Direction = Util.Enums.Direction.Right;
                temp.transform.position = actor.CurrentNode.Right.transform.position;
                temp.CurrentNode = actor.CurrentNode.Right;
            }
        }
    }
}
