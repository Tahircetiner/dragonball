using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ThreadState = System.Threading.ThreadState;

namespace DragonBall{
    internal class Program{
        private static BattleArena battleArena = new BattleArena();
        private static bool isGaming = true;
        private static Thread firstThread;
        private static Thread secondThread;
        public static void Main(string[] args){
            battleArena.selectCharacter();
            battleArena.runGame();
        }
        //Starten einer Transformation -> Noch nicht fertig implementiert
        public static void waitLimitedMilliseconds(){
            Thread.Sleep(5000);
            Console.WriteLine("WIrd das auch ausgeführt?");
            battleArena.isLevelingUp = false;
        }

        public static void readFromUserInput(){
            String levelString = Console.ReadLine();
            Console.WriteLine("reading from user input");
            Console.WriteLine("BATTLEARENA " + battleArena.isLevelingUp);
            Console.WriteLine("THREAD 1 " + firstThread.ThreadState);
            Console.WriteLine("THREAD 2 " + secondThread.ThreadState);
            if (secondThread.ThreadState == ThreadState.WaitSleepJoin) {
                secondThread.Abort();
            }
            if (levelString.Equals("Fischer's Fritz fischt große Fische")) {
                Console.WriteLine("DU bist ein Level aufgestiegen");
                // Hier muss nun ein Levelaufstieg realisiert werdewn
            }
            
        }
    }
    
}