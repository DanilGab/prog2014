using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
		
		public int window; 
		
		void Start () { 
			window = 1; 
		} 
		
		void OnGUI () { 
			GUI.BeginGroup (new Rect (Screen.width / 2 - 10, Screen.height / 2 - 10, 200, 200)); 
			if(window == 1) 
			{ 
				if(GUI.Button (new Rect (10,30,180,30), "Играть")) 
				{ 
					window = 2;   
				}  
				if(GUI.Button (new Rect (10,80,180,30), "Об Игре")) 
				{ 
					window = 4; 
				} 
				if(GUI.Button (new Rect (10,150,180,30), "Выход")) 
				{ 
					window = 5; 
				} 
			} 
			
			if(window == 2) 
			{ 
				GUI.Label(new Rect(50, 10, 180, 30), "Выберите уровень");   
				if(GUI.Button (new Rect (10,40,180,30), "Уровень 1")) 
				{ 
					Debug.Log("Уровень 1 загружен"); 
					Application.LoadLevel(1); 
				} 
				if(GUI.Button (new Rect (10,80,180,30), "Уровень 2")) 
				{ 
					Debug.Log("Уровень 2 загружен"); 
					Application.LoadLevel(2); 
				} 
				if(GUI.Button (new Rect (10,120,180,30), "Уровень 3")) 
				{ 
					Debug.Log("Уровень 3 загружен"); 
					Application.LoadLevel(3); 
				} 
				if(GUI.Button (new Rect (10,160,180,30), "Назад")) 
				{ 
					window = 1; 
				} 
			} 
			
			
			
			if(window == 4) 
			{ 
				GUI.Label(new Rect(50, 10, 180, 30), "Об Игре");   
				GUI.Label(new Rect(10, 40, 180, 40), "Игра предазначена для двух игроков. Каждому нужно перехватить сферу и добраться вместе с ней до своего телепорта. "); 
				if(GUI.Button (new Rect (10,150,180,30), "Назад")) 
				{ 
					window = 1; 
				}   
			} 
			
			if(window == 5) 
			{ 
				GUI.Label(new Rect(50, 10, 180, 30), "Вы уже выходите?");   
				if(GUI.Button (new Rect (10,40,180,30), "Да")) 
				{ 
					Application.Quit(); 
				} 
				if(GUI.Button (new Rect (10,80,180,30), "Нет")) 
				{ 
					window = 1; 
				} 
			} 
			GUI.EndGroup (); 
		} 
	}