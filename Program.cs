using System;
using System.Collections.Generic;

namespace challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Extension (optional) (as above, but include):
            // 1.	Allow each roll to consist of two dice.
            // Extra Extension (optional):
            // 1.	Allow the user to specify how many dice are used for each roll.  This won’t change until the program is finished

            Console.WriteLine("welcome to diceroller dx");

            // Console.Write("how many dice would you like to roll each time? ");
            // int noOfDice = NumberInput();

            
            // 2.	Allow the user to select how many sides are on the die to be rolled.
            Console.Write("how many sides should each dice have? ");
            int sidesOfDice = NumberInput();
            while (sidesOfDice<1){
                Console.WriteLine("dice must have positive number of sides");
                sidesOfDice = NumberInput();
            }

            List<int> diceList = new List<int>();

            // 1.	Allow the user to roll dice
            Console.Write("type \"roll\" to roll, or type \"stop\" to stop rolling and examine dice rolls: ");
            string rollInput = RollInput();

            while(rollInput=="r"){
            // 2.	Store the dice rolls
                RollFunction(diceList, sidesOfDice);
                Console.Write("type \"roll\" to roll, or type \"stop\" to stop rolling and examine dice rolls: ");
                rollInput = RollInput();
            } 
            // 3.	When user chooses, stop
            // i.e. when rollInput isn't r, it will be s, i.e. stop
            StopFunction(diceList);
            
            // 4.	Allow user to enter number of rolls to examine
            List<int> diceListToExamine = ExamineInput(diceList);
                        
            // 5.	From the stored rolls, calculate
            ExamineOutput(diceList,diceListToExamine);            

            Console.WriteLine("goodbye!");
        }
        static int NumberInput(){
            string NumberInput = Console.ReadLine();
            int intNumberInput;
            while(!int.TryParse(NumberInput, out intNumberInput))
            {
                Console.Write("Sorry, I didn't understand that, please enter whole number as a numeral: ");
                NumberInput = Console.ReadLine();
            }
            return intNumberInput;
        }
        static string RollInput(){
            string rollInput = Console.ReadLine();
            bool valid=false;
            if (rollInput.ToLower()=="r"||rollInput.ToLower()=="roll"){
                rollInput="r";
                valid=true;
            }
            if (rollInput.ToLower()=="s"||rollInput.ToLower()=="stop"){
                rollInput="s";
                valid=true;
            }
            while(!valid)
            {
                Console.Write("i'm sorry, i didn't understand that, please input a command: ");
                rollInput = Console.ReadLine();
                if (rollInput.ToLower()=="r"||rollInput.ToLower()=="roll"){
                rollInput="r";
                valid=true;
                }
                if (rollInput.ToLower()=="s"||rollInput.ToLower()=="stop"){
                    rollInput="s";
                    valid=true;
                }
            }
            return rollInput;
        }
        static void RollFunction(List<int> diceList, int sidesOfDice){
            var random = new Random();

            int num = random.Next(1,sidesOfDice+1);
            
            diceList.Add(num);

            Console.WriteLine("rolled "+num);
        }
        static void StopFunction(List<int> diceList){
            Console.WriteLine("you rolled: ");
            for(int i = 0; i < diceList.Count; i++){
                Console.WriteLine("roll "+(i+1)+": "+diceList[i]);
            }
        }

        static List<int> ExamineInput(List<int> diceList){
            // when this is true, move to examine output
            bool examine = false;

            int examineNumber = 0;
            List<int> diceListExamine = new List<int>();

            // if there are no rolls, there is nothing to add to examination, so move to output
            if(diceList.Count==0){
                examine = true;
            }

            while(!examine){

                Console.Write("select a roll number to add that many rolls to examine: ");
                examineNumber=NumberInput();
                if(examineNumber<=diceList.Count && examineNumber>=1){
                    for(int j=0; j<examineNumber; j++){
                        diceListExamine.Add(j+1);
                    }
                    examine=true;
                } else {
                    Console.WriteLine("number was too large or small, input a number");
                }

                // if(examineInput.ToLower()=="e"||examineInput.ToLower()=="examine"){
                //     examine=true;
                // }
                // if (int.TryParse(examineInput, out examineNumber)){
                //     if(diceListExamine.Contains(examineNumber)){
                //         Console.WriteLine("roll already in examine list");
                //     } else if(examineNumber<=diceList.Count && examineNumber>=1){
                //         diceListExamine.Add(examineNumber);
                //         Console.WriteLine("added roll "+examineNumber+" (value: "+diceList[examineNumber-1]+") to examination list");
                //     } else {
                //         Console.WriteLine("sorry, i didn't understand that");
                //     }
                // }
            }
            return diceListExamine;
        }

        static void ExamineOutput(List<int> diceList, List <int> diceListExamine){
            if(diceListExamine.Count>0){
                // 3.	List what the rolls were
                Console.Write("stored rolls are:");
                for(int i = 0; i < diceListExamine.Count; i++){
                    Console.Write(" "+diceList[diceListExamine[i]-1]);
                }
                Console.WriteLine("");

                // 2.	Total
                int examineTotal = 0;
                for(int i = 0; i < diceListExamine.Count; i++){
                    examineTotal+=diceList[diceListExamine[i]-1];
                }
                Console.WriteLine("total of these rolls is: "+examineTotal);

                // 1.	Average
                decimal examineAvg = (decimal)examineTotal / diceListExamine.Count;
                Console.WriteLine("average of these rolls is: "+examineAvg);
            }
        }

    }
}
