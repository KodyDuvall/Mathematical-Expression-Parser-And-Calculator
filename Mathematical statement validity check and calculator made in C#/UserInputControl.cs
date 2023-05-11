public class UserInputControl{
    CheckCharacterValidity checkCharacterValidity = new CheckCharacterValidity();
    ParenthesesParser parenthesesParser = new ParenthesesParser();
    NegativeNumbersHandler negativeNumbersHandler = new NegativeNumbersHandler();

    string userInput = String.Empty;

    public void StartProgram(){
        Introduction();
    }

    private void Introduction(){
        System.Console.WriteLine();
        System.Console.WriteLine("This is an application that can parse an input of a mathematical expression that is in a single string.");
        System.Console.WriteLine("This application will parse it such that it becomes calculable, and then it will display the calculated result.");
        System.Console.WriteLine();        
        System.Console.WriteLine("If you want to learn more about the specifics of this program, type L and press enter.");
        System.Console.WriteLine("Otherwise, just press enter to proceed.");
        System.Console.WriteLine();
        System.Console.Write(">");

        userInput = Console.ReadLine()!;

        if(userInput == "L" || userInput == "l"){
            MoreInformation(true);
            MainProgram();
        }

        else{
            MainProgram();
        }
        
    }

    private void MoreInformation(bool isFromIntroduction){
        List<string> lines = new List<string>();
        string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "MoreInformationText.txt";
        lines = File.ReadAllLines(filePath).ToList();
        //Below are examples of acceptable inputs, with their associated outputs:
        System.Console.WriteLine();
        System.Console.WriteLine();

        if(isFromIntroduction){
            for(int i = 0; i < lines.Count; i++){
                if(lines[i] == "~"){
                    System.Console.Write("Press the enter key to continue");
                    Console.ReadLine();
                }

                else{
                    System.Console.WriteLine(lines[i]);
                }
            }
        }

        else{
            for(int i = 0; i < lines.Count; i++){
                if(lines[i] == "Below are examples of acceptable inputs, with their associated outputs:"){
                    for(int I = i; I < lines.Count; I++){
                        if(lines[I] != "~"){
                            System.Console.WriteLine(lines[I]);
                        }
                    }

                    System.Console.Write("Press the enter key to continue");
                    Console.ReadLine();

                    break;
                }
            }
        }

        System.Console.WriteLine();
        System.Console.WriteLine();

    }

    private void MainProgram(){
        while(true){
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Enter a mathematical expression. When you're done using this application, type D and press enter.");
            System.Console.WriteLine();
            System.Console.Write(">");

            userInput = Console.ReadLine()!;

            if(userInput == "D" || userInput == "d"){
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine("Program shutting down.");
                System.Console.WriteLine();
                System.Console.WriteLine();

                System.Environment.Exit(0);
            }

            else{
                if(!checkCharacterValidity.CheckValidity(userInput)){
                    System.Console.WriteLine();
                    System.Console.WriteLine("That was not a valid input.");
                    System.Console.WriteLine("If you like to learn why, type W and press enter.");
                    System.Console.WriteLine("Otherwise, just press enter to continue.");
                    System.Console.WriteLine();
                    System.Console.Write(">");

                    userInput = Console.ReadLine()!;

                    if(userInput == "W" || userInput == "w"){
                        MoreInformation(false);
                    }
                }

                else{
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                    userInput = negativeNumbersHandler.FindAndOrganizeNegativeNumbers(userInput);
                    System.Console.WriteLine("The final calculated result is: " + parenthesesParser.ParseParentheses(userInput));
                    System.Console.WriteLine();
                    System.Console.Write("Press the enter key to continue.");
                    Console.ReadLine();
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                }
            }
        }
    }
}
