﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Enemies
{
	class Mechbot : Enemy {
		[SerializeField]
		private GameObject bullet;
		
		private Player.Player player;
		private float turn = 0;
		public Animator	mechAnima;
		
		protected override void Initialize()
		{
			player = FindObjectOfType<Player.Player>();
			mechAnima.GetComponent<Animator>();
		}
		
		protected override void RunAI()
		{
			//We change turns each second
			turn += Time.deltaTime;
			if(!hit){
			if(turn > 1f)
			{
				turn = 0;
				//If player is above us
				if(player.CurrentNode.Position.x < currentNode.Position.x)
				{
					//Check if we can move up.
					if (!currentNode.Up.Occupied)
					{
						mechAnima.SetTrigger("Wait");
						currentNode.clearOccupied();//Say we aren't here
						currentNode = currentNode.Up;//Say we're there
						currentNode.Owner = (this);//Tell the place we own it.
					}
				}
				//If player is above us
				else if (player.CurrentNode.Position.x > currentNode.Position.x)
				{
					//Check if we can move up.
					if (!currentNode.Down.Occupied)
					{
						mechAnima.SetTrigger("Wait");
						currentNode.clearOccupied();//Say we aren't here
						currentNode = currentNode.Down;//Say we're there
						currentNode.Owner = (this);//Tell the place we own it.
					}
				}
				//If they are in front of us, ATTACK!.
				else
				{
					mechAnima.SetTrigger("Fire");
					Weapons.Hitbox b = Instantiate(bullet).GetComponent<Weapons.Hitbox>();
					b.transform.position = currentNode.Left.transform.position;
					b.CurrentNode = currentNode.Left;
				}
			}
		
			}
			else{
				mechAnima.SetTrigger("Hurt");
				turn=0;
			}
		}
	
	}
}
