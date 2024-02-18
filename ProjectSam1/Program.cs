using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectSam
{
	class Program
	{
//struct
		//เป็นคลาสที่เอาไว้กำหนดตัวแปรของออฟเจคอื่นๆที่ใช้ตัวแปรเหมือนๆกัน
		struct Other
		{
			public int X;
			public int Y;
			public ConsoleColor color;
		}
		//เป็นคลาสที่เอาไว้กำหนดตัวแปรของเหรียญ
		struct Coins
		{
			public int X;
			public int Y;
			public string symbol;
			public ConsoleColor color;
		}
	
//Print
//เป็นฟังก์ชั่นที่เอาไว้แสดงสิ่งต่างๆบนหน้าจอ
		//แสดงตัวละครผู้เล่น
		static void PrintPlayer(int X, int Y, ConsoleColor color)
		{
			Console.SetCursorPosition(X, Y); //เซตตำแหน่ง
			Console.ForegroundColor = color; //เซตสี
			Console.Write("O"); //แสดงตัวอักษร
			Console.SetCursorPosition(X - 1, Y + 1);
			Console.Write("/|7");
			Console.SetCursorPosition(X - 1, Y + 2);
			Console.Write("/ L");

		}
		//แสดงหนาม
		static void PrintThorn(int X, int Y, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(X, Y);
			Console.Write("!!");
		}
		//แสดงห่วง
		static void PrintRect(int x, int y, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x, y);
			Console.Write("*");
			Console.SetCursorPosition(x, y - 7);
			Console.Write("*");
		}
		//แสดงเส้นชัย
		static void PrintWin(int x, int y)
		{
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x,y);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y-1);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y-2);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y-3);
			Console.Write("|    |####|");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y-4);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 5);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y-6);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 7);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 8);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 9);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 10);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 11);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 12);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 13);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 14);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 15);
			Console.Write("|    |####");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 16);
			Console.Write("|####|    |");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x, y - 17);
			Console.Write("|    |####");





		}
		//แสดงสิ่งต่างๆที่ใช้รูปแบบ symbol 
		static void Print(int x, int y, string symbol, ConsoleColor color)
		{
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = color;
			Console.Write(symbol);
		}
		//แสดงตัวข้อความ
		static void PrintString(int x,int y,string text,ConsoleColor color)
		{
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = color;
			Console.Write(text);
		}
		//แสดงเส้นขั้นระหว่างอิฐ
		static void PrintBlock1(int x, int y, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x, y + 1);
			Console.Write("|");
			Console.SetCursorPosition(x, y + 2);
			Console.Write("|");
			Console.SetCursorPosition(x, y + 3);
			Console.Write("|");

		}
		//แสดงอิฐ
		static void PrintBlock2(int x, int y, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x, y + 1);
			Console.Write("#");
			Console.SetCursorPosition(x, y + 2);
			Console.Write("#");
			Console.SetCursorPosition(x, y + 3);
			Console.Write("#");

		}

		static void Main(string[] args)
		{
			int WinWidth = 100; //ความกว้างจอ
			int WinHeight = 25; //ความสูงจอ
			int Ground = WinHeight-7; //ความสูงพื้น
			bool TouchGround = true; //เช็คการแตะพื้น
			int Frame = 1; //เอาไว้กำหนดจุดที่จะเรียกออฟเจคออกมา
			string coinsSymbol; //เอาไว้กำหนด symbol
			int score = 0; //กอ
			int Level = 1; //เลเวล
			int Live = 9; //ชีวิต
			int speed = 30; //ความเร็วเกม
			bool ThornOpen = false; //เปิด-ปิด หนาม
			bool RectOpen = false; //เปิด-ปิด ห่วง
			bool FloorOpen = false; //เปิด-ปิด พื้นต่างระดับ
			bool IsgameWin = false; //เช็คชนะหรือเข้าเส้นชัย
			bool PuchupOpen = true; //เช็คโดดกลางอากาศ
			bool JumpOnFloor = false; //เช็คการอยู่บนพื้นต่างระดับ
			bool CheckFloor = false; //เช็คการอยู่ในช่วงของพื้นต่างระดับ
			bool Jump = false; //เปิด-ปิด การโดด
			int PuchCount = 0; //จำนวนการกด
			int PuchTime = 0; //เวลาที่จะโดดครั้งที่สองได้(ขณะอยู่กลางอากาศ)			
			int countJump = 0; //เวลาในการกระโดดขึ้น

			Console.BufferWidth = Console.WindowWidth = WinWidth; //กำหนดความกว้างจอ
			Console.BufferHeight = Console.WindowHeight = WinHeight; //กำหนดความสูงจอ
			
			//กำหนดตำแหน่งและสีของตัวละคร
			Other player;
			player.X = WinWidth*4/7;
			player.Y = Ground;
			player.color = ConsoleColor.Cyan;

			List<Other> Blocklist = new List<Other>(); //เอาไว้เก็บค่าบล๊อค
			List<Other> Thornlist = new List<Other>(); //เอาไว้เก็บค่าหนาม
			List<Other> Rectlist = new List<Other>(); //เอาไว้เก็บค่าห่วง
			List<Other> Floorlist = new List<Other>(); //เอาไว้เก็บค่าพื้นต่างระดับ
			List<Coins> Coinslist = new List<Coins>(); //เอาไว้เก็บค่าเหรียญ
			List<Other> BlocklistEnd = new List<Other>(); //เอาไว้เก็บค่าเส้นชัย

			bool IsgameRining = true;//เปิด-ปิด การวนลูปของเกม

			while (IsgameRining) //ลูปเกม
			{

//player
			//เอาไว้โดดขึ้น-ลงของตัวละคร
					if (Jump)
					{
						player.Y--; //ตัวละครโดดขึ้น
					}
					else if (TouchGround && player.Y < Ground && Frame % 2 == 0)
					{
						player.Y++; //ตัวละครโดดลง
					}
	

//Block (พื้นแบล๊คกราว)
				Random Blockran = new Random(); //กำหนดตัวแปรสุ่ม
				int blockChange = Blockran.Next(0, 15); //กำหนดค่าที่จะสุ่ม
				if (blockChange < 14) //กำหนดค่าสุ่ม ถ้าน้อยกว่า 14 จะเกิดอิฐ ถ้ามากกว่าหรือเท่า 14 จะเป็นช่องว่า (ช่องว่างทำให้พื้นดูเคลื่อนไหว ถ้าไม่มีจะเหมือนอยู่กับที่)
				{
					Other newBlock = new Other();
					newBlock.X = 0;
					newBlock.Y = Ground + 3;
					newBlock.color = ConsoleColor.DarkGreen;
					Blocklist.Add(newBlock); //เพิ่มตัวแปรลงในลิส
				}

				List<Other> newBlocklist = new List<Other>(); //เอาไว้เก็บตัวแปรที่จะแสดงบนหน้าจอ
				for (int i = 0; i < Blocklist.Count; i++)
				{
					Other oldblock = Blocklist[i];
					if (oldblock.X < WinWidth - 2)
					{
						Other moveBlock = new Other();
						moveBlock.X = oldblock.X + 1;
						moveBlock.Y = oldblock.Y;
						moveBlock.color = oldblock.color;
						newBlocklist.Add(moveBlock);

					}
				}

//Thorn (หนาม)
				if (FloorOpen && Frame / 1 == Frame) //เมื่อเปิด Floor หนามจะแสดงทุกๆพิกเซลแบบติดๆกัน
				{
					Other newThorn = new Other();
					newThorn.X = 0;
					newThorn.Y = Ground + 2;
					newThorn.color = ConsoleColor.Red;
					Thornlist.Add(newThorn);

				}

				if (ThornOpen && Frame % 23 == 0) //เมื่อเปิด Thorn หนามจะแสดงทุก 23 พิกเซล
				{
					Other newThorn = new Other();
					newThorn.X = 0;
					newThorn.Y = Ground + 2;
					newThorn.color = ConsoleColor.Red;
					Thornlist.Add(newThorn);
				}


				List<Other> newThornlist = new List<Other>();
				for (int i = 0; i < Thornlist.Count; i++)
				{
					Other oldThorn = Thornlist[i];
					if (oldThorn.X < WinWidth - 2)
					{
						Other moveThorn = new Other();
						moveThorn.X = oldThorn.X + 1;
						moveThorn.Y = oldThorn.Y;
						moveThorn.color = oldThorn.color;
						newThornlist.Add(moveThorn);

						//เช็คตัวละครชนกับหนาม ถ้าชนจะลดชีวิต
						if ((moveThorn.X == player.X && moveThorn.X == player.X) && moveThorn.Y == player.Y + 2) { Live--; }

					}

				}

//Floor	(พื้นต่างระดับ)		
				//เมื่อเปิด Floor จะแสดง Floor และเกิดช่องว่างจากทุกๆพิกเซลที่กำหนด
				if (FloorOpen && (Frame % 30 != 0 && Frame % 30 != 1 && Frame % 30 != 2 && Frame % 30 != 3 &&
						Frame % 30 != 4 && Frame % 30 != 5 && Frame % 30 != 6 && Frame % 30 != 7 && Frame % 30 != 8))
				{
						Other newFloor = new Other();
						newFloor.X = 0;
						newFloor.Y = Ground;
						newFloor.color = ConsoleColor.Green;
						Floorlist.Add(newFloor);
				}

				List<Other> newFloorlist = new List<Other>();
				for (int i = 0; i < Floorlist.Count; i++)
				{
					Other oldFloor = Floorlist[i];
					if (oldFloor.X < WinWidth - 2)
					{
						Other moveFloor = new Other();
						moveFloor.X = oldFloor.X + 1;
						moveFloor.Y = oldFloor.Y;
						moveFloor.color = oldFloor.color;
						newFloorlist.Add(moveFloor);

						//ถ้าตัวละครโดน Floor
						if (moveFloor.X == player.X && moveFloor.Y-2 <= player.Y && moveFloor.Y-1 >= player.Y)
						{
							player.Y = moveFloor.Y - 2; //ตัวละครจะอยู่บน Floor
							TouchGround = false; //ตัวละครจะไม่ตกถึงพื้นข้างล่าง Floor
							JumpOnFloor = true; //เช็คว่าอยู่บน Floor
							CheckFloor = true; //เช็คว่าอยู่ในช่วงของ Floor (เอาไว้แก้บัค)
						}
						else if (moveFloor.X != player.X && moveFloor.Y - 2 <= player.Y && moveFloor.Y - 1 >= player.Y)
						{
							TouchGround = false;
							CheckFloor = true;
						}
						else { TouchGround = true; JumpOnFloor = false; CheckFloor = false; }
					}

				}
//Rect
				//เมื่อเปิด Rect แสดงห่วงออกมาแบบสุ่มช่วงและความสูงของห่วง
				if (RectOpen)
				{
					Random Rectran = new Random();
					int RectranX = Rectran.Next(0, 5);
					int Rectspond;
					if(RectranX == 1)
					{
						Rectspond = 30;
					}
					else { Rectspond = 60; }
					if (Frame % Rectspond == 0)
					{
						Other newRect = new Other();

						if (RectranX <= 1)
						{
							newRect.Y = Ground - 1;
						}
						if(RectranX <= 3 && RectranX > 1)
						{
							newRect.Y = Ground + 1;
						}
						if(RectranX >= 3)
						{
							newRect.Y = Ground;
						}
						
						newRect.X = 0;
						newRect.color = ConsoleColor.White;
						Rectlist.Add(newRect);
					}
				}

				List<Other> newRectlist = new List<Other>();
				for (int i = 0; i < Rectlist.Count; i++)
				{
					Other oldRect = Rectlist[i];
					if (oldRect.X < WinWidth - 2)
					{
						Other moveRect = new Other();
						moveRect.X = oldRect.X + 1;
						moveRect.Y = oldRect.Y;
						moveRect.color = oldRect.color;
						newRectlist.Add(moveRect);

						//เช็คถ้าผู้เล่นชนขอบห่วงชีวิตจะลด
						if ((moveRect.X == player.X) && ((moveRect.Y >= player.Y && moveRect.Y <= player.Y + 2) || (moveRect.Y - 7 >= player.Y && moveRect.Y - 7 <= player.Y + 2))) { Live--; }
						//เช็คถ้าผู้เล่นลอดห่วงจะเพิ่ม score 1 แต้ม
						if ((moveRect.X == player.X) && (moveRect.Y > player.Y + 2 && moveRect.Y - 7 < player.Y)) { score++; }

					}

				}

//coins (เหรียญ)
				
				//ทำให้เหรียญเกิดทุกๆ 37 พิกเซล
				if (Frame % 37 == 0)
				{
					Random AllrandCoins = new Random();
					int randCoinsY = AllrandCoins.Next(0, 100); //สุ่มความสูงของเหรียญ
					Coins newCoins = new Coins();

					//ค่าความสูงจากการสุ่ม
					if (randCoinsY <= 30)
					{
						newCoins.Y = Ground;
					}
					else
					{
						newCoins.Y = Ground - 4;
					}

					//สุ่มรูปแบบเหรียญ
					if (randCoinsY > 20 && randCoinsY <= 30)
					{
						coinsSymbol = "H";
						newCoins.color = ConsoleColor.Green;
					}
					else if (randCoinsY <= 10)
					{
						coinsSymbol = "X";
						newCoins.color = ConsoleColor.Red;
					}
					else if (randCoinsY > 10 && randCoinsY <= 20)
					{
						coinsSymbol = "Y";
						newCoins.color = ConsoleColor.Magenta;
					}
					else
					{
						coinsSymbol = "$";
						newCoins.color = ConsoleColor.Yellow;
					}

					newCoins.X = 0;
					newCoins.symbol = coinsSymbol;
					Coinslist.Add(newCoins);
				}

				List<Coins> newCoinslist = new List<Coins>();
				for (int i = 0; i < Coinslist.Count; i++)
				{
					Coins oldCoins = Coinslist[i];
					if (oldCoins.X < WinWidth - 2)
					{
						Coins moveCoins = new Coins();
						moveCoins.X = oldCoins.X + 1;
						moveCoins.Y = oldCoins.Y;
						moveCoins.symbol = oldCoins.symbol;
						moveCoins.color = oldCoins.color;
						newCoinslist.Add(moveCoins);

						//เช็ค ถ้าผู้เล่นชนเหรียญ $ สกอจะเพิ่ม 10 แต้ม
						if (player.X == moveCoins.X && (moveCoins.Y >= player.Y && moveCoins.Y <= player.Y + 2) && moveCoins.color == ConsoleColor.Yellow)
						{
							score += 10;
							newCoinslist.Clear(); //ลบเหรียญที่ถูกชน
						}

						//เช็ค ถ้าผู้เล่นชนเหรียญ X จะลดชีวิต 1 แต้ม
						if (player.X == moveCoins.X && (moveCoins.Y >= player.Y && moveCoins.Y <= player.Y + 2) && moveCoins.color == ConsoleColor.Red)
						{
							Live--;
							newCoinslist.Clear();
						}

						//เช็ค ถ้าผู้เล่นชนเหรียญ Y จะลดสกอ 5 แต้ม
						if (player.X == moveCoins.X && (moveCoins.Y >= player.Y && moveCoins.Y <= player.Y + 2) && moveCoins.color == ConsoleColor.Magenta)
						{
							score -= 5;
							newCoinslist.Clear();
						}

						//เช็ค ถ้าผู้เล่นชนเหรียญ H จะเพิ่มสกอ 5 เต้ม และ เพิ่มชีวิต 1 เเต้ม
						if (player.X == moveCoins.X && (moveCoins.Y >= player.Y && moveCoins.Y <= player.Y + 2) && moveCoins.color == ConsoleColor.Green)
						{
							score += 5;
							Live++;
							newCoinslist.Clear();
						}
					}

				}

//GameEnd (เช็คการจบของเกม)

				//ถ้าเงื่อนไขครบจะแสดงเส้นชัย
				if (Level >= 9 && score >= 300 && Frame % 65 == 0) //เงื่อนไขการชนะ
				{
					Other newBlockEnd = new Other();
					newBlockEnd.X = 0;
					newBlockEnd.Y = Ground+2;
					newBlockEnd.color = ConsoleColor.DarkGreen;
					BlocklistEnd.Add(newBlockEnd);
				}

				List<Other> newBlocklistEnd = new List<Other>();
				for (int i = 0; i < BlocklistEnd.Count; i++)
				{
					Other oldblock = BlocklistEnd[i];
					if (oldblock.X < WinWidth - 2)
					{
						Other moveBlockEnd = new Other();
						moveBlockEnd.X = oldblock.X + 1;
						moveBlockEnd.Y = oldblock.Y;
						moveBlockEnd.color = oldblock.color;
						newBlocklistEnd.Add(moveBlockEnd);

						//เช็ค ถ้าผู้เล่นเข้าเส้นชัย
						if (moveBlockEnd.X + 7 > player.X)
						{
							IsgameRining = false; //หยุดเกม
							IsgameWin = true; //แสดงข้อความชนะ
						}
						else { IsgameRining = true; }

					}

				}

//Update
//Key (การกดคี)

				//การโดดบนพื้น (ตอนเปิด Floor)
				if ((TouchGround == false && CheckFloor))
				{
					if (player.Y >= Ground)
					{
						PuchCount = 0; //รีการนับจำนวนการโดดให้สามารถโดดได้
					}
				}

				//การโดดบน Floor (ตอนเปิด Floor)
				if (JumpOnFloor && CheckFloor)
				{
					if (player.Y >= Ground - 2)
					{
						PuchCount = 0;
					}
				}

				//อยู่บนพื้นทั่วไป
				else
				{
					if (player.Y >= Ground)
					{
						PuchCount = 0;
					}
				}

				//ถ้าเฟรมในการโดดเป็นตามเงื่อนไข จะสามารถกดโดดครั้งที่สองได้
				if (PuchTime >= 13 && PuchCount < 2) 
				{
					PuchupOpen = true;
					PuchTime = 0;
				}
				//ถ้ากดโดดครบสองครั้ง จะไม่สามารถกดโดดได้อีกจนกว่าจะแตะพื้น
				else if (PuchCount == 2) 
				{
					PuchupOpen = false;
				}

				if (Console.KeyAvailable && PuchupOpen) //เช็คการกดคีย์
				{
					ConsoleKeyInfo keyPressed = Console.ReadKey(true); //รับคีย์ว่าผู้เล่น
 
					//ถ้าผู้เล่นกด Spacebar การโดดจะทำงาน
					if (keyPressed.Key == ConsoleKey.Spacebar)
					{
						if (player.Y > 0)
						{
							if(player.Y > Ground - 6)
							{
								TouchGround = false;
								PuchupOpen = false;
							}
							
						}
						Jump = true; 
					}
					PuchCount++; //นับจำนวนการกด
				}


//Player
				//ควบคุมเลเวลให้ไม่เกิน 9
				if (Live <= 0)
				{
					IsgameRining = false;
				}
				Level = score / 30 + 1;

			//จัดการด่านของแต่ละเลเวล
				//มีหนามออกมา
				if (Level == 1) 
				{
					ThornOpen = true;
					RectOpen = false;
					FloorOpen = false;
				}
				//มีห่วงออกมา
				if(Level == 2) 
				{
					ThornOpen = false;
					RectOpen = true;
					FloorOpen = false;
				}
				//มีทั้งหนามทั้งห่วง
				if(Level == 3)
				{
					ThornOpen = true;
					RectOpen = true;
					FloorOpen = false;
				}
				//เพิ่มความเร็วจากเดิม
				if(Level == 4)
				{
					ThornOpen = true;
					RectOpen = true;
					FloorOpen = false;
					Thread.Sleep(speed-7); //เพิ่มความเร็วของเกม
				}
				//มีพื้นต่างระดับ และ มีหนามด้านล่าง
				if(Level == 5)
				{
					ThornOpen = true;
					RectOpen = false;
					FloorOpen = true;
				}
				//เพิ่มความเร็วจากเดิม
				if(Level == 6)
				{
					ThornOpen = true;
					RectOpen = false;
					FloorOpen = true;
					Thread.Sleep(speed - 14);
				}
				//มีพื้นต่างระดับ ห่วง และ หนามด้านล่าง
				if (Level == 7)
				{
					ThornOpen = true;
					RectOpen = true;
					FloorOpen = true;
				}
				//เพิ่มความเร็วจากเดิม
				if(Level == 8)
				{
					ThornOpen = true;
					RectOpen = true;
					FloorOpen = false;
					Thread.Sleep(speed - 21);
				}
				//มีหนามและห่วงและเพิ่มความเร็ว
				else if (Level >= 9)
				{
					Level = 9;
					ThornOpen = true;
					RectOpen = true;
					FloorOpen = false;
					Thread.Sleep(speed - 28);
				}


				if (Jump) //ถ้าคำสั่งกระโดดทำงาน
				{
					countJump++; //นับพิกเซลในการโดดขึ้น
				}

				//ถ้าพิกเซลการกระโดดมากกว่าหรือเท่า เงื่อนไข จะทำให้ตกลงสู่พื้น
				if (countJump >= 7) 
				{
					Jump = false;
					TouchGround = true;
					countJump = 0;
				}
				else { TouchGround = true; } //ตัวละครตกลงสู่พื้น

				//อัพเดทลิส หลังจากอัพเดทแล้ว ลิสพวกนี้จะถูกลบ
				Blocklist = newBlocklist;
				Thornlist = newThornlist;
				Floorlist = newFloorlist;
				Rectlist = newRectlist;
				Coinslist = newCoinslist;
				BlocklistEnd = newBlocklistEnd;
				Frame++; //เพิ่มค่า Frame
				PuchTime++; //เพิ่มค่า PuchTime
				Console.Clear(); //ลบการแสดงผลบนจอของลูปก่อนหน้า

//Draw

				PrintString(WinWidth * 9 / 11, (WinHeight / 10) / 2, "Score:" + score,ConsoleColor.White); //แสดงข้อความ Score
				PrintString(WinWidth * 5 / 11, (WinHeight / 10) / 2, "Level:" + Level, ConsoleColor.White); //แสดงข้อความ Level
				PrintString(WinWidth * 1 / 11, (WinHeight / 10) / 2, "Live:" + Live, ConsoleColor.White); //แสดงข้อความ Live

				//ลูปแสดง Thorn จะแสดงตามลำดับของตัวแปรที่ถูกบรรจุในลิส
				for (int i = 0; i < newThornlist.Count; i++)
				{
					Other thisThorn = Thornlist[i]; //เรียกใช้ค่าจากตัวแปรที่เก็บไว้ในลิส
					PrintThorn(thisThorn.X, thisThorn.Y, thisThorn.color);
				}

				//ลูปแสดง Floor
				for (int i = 0; i < newFloorlist.Count;i++)
				{
					Other thisFloor = Floorlist[i];
					Print(thisFloor.X, thisFloor.Y,"_", thisFloor.color);
				}

				//ลูปแสดง Rect
				for (int i =0; i < newRectlist.Count;i++)
				{
					Other thisRect = Rectlist[i];
					PrintRect(thisRect.X, thisRect.Y, thisRect.color);
				}

				//ลูปแสดง Coins
				for (int i = 0; i < newCoinslist.Count; i++)
				{
					Coins thisCoins = Coinslist[i];
					Print(thisCoins.X, thisCoins.Y, thisCoins.symbol, thisCoins.color);
				}

				//ลูปแสดง เส้นชัย
				for (int i = 0; i < newBlocklistEnd.Count;i++)
				{
					Other thisBlockEnd = BlocklistEnd[i];
					PrintWin(thisBlockEnd.X, thisBlockEnd.Y);
				}

				//ลูปแสดง Block
				for (int i = 0; i < newBlocklist.Count; i++)
				{
					Other thisBlock = Blocklist[i];

					//ทำให้เส้นขั้น(|)แสดงทุก 4 ช๊าป(#) (จะทำให้ดูเป็นบล๊อคมากขึ้น)
					if (i % 4 == 0)
					{
						PrintBlock1(thisBlock.X, thisBlock.Y, thisBlock.color);
					}
					else
					{
						PrintBlock2(thisBlock.X, thisBlock.Y, thisBlock.color);
					}

				}

				//ลูปแสดงเส้นขั้นของขอบจอและพื้น
				for (int i = 0; i <= WinWidth - 2; i++)
				{
					Print(i, Ground+3, "=", ConsoleColor.DarkGreen);
					Print(i, WinHeight / 10, "_", ConsoleColor.White);
				}

				//แสดงตัวละครผู้เล่น
				PrintPlayer(player.X, player.Y, player.color);

				Thread.Sleep(speed); //ตัวกำหนดความเร็วของเกม
			}

			//แสดงข้อความเมื่อชนะ
			if(IsgameWin)
			{
				PrintString(WinWidth / 2 - 4, WinHeight / 2, "GAME SUCCESS\n", ConsoleColor.Cyan);
			}
			else //เมื่อแพ้
			{
				PrintString(WinWidth / 2 - 4, WinHeight / 2, "GAME OVER\n", ConsoleColor.Red);
			}
			

		}
	}
}
