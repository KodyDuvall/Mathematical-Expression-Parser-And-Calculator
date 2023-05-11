public class SegmentCalculator{
    public string CalculateSegment(string str){//This could go in its own class
		string result = String.Empty;
        double num;
        string resultantString = String.Empty;
        string tempString = String.Empty;
        List<string> listOfNumbers = new List<string>();
        List<char> listOfOperators = new List<char>();
        //this loop can be refactored. I possibly don't need the checks for '-' if it enters the while loop because of the presence
        //of '-', then it shouldn't be poisslbe to enter the loop unless i == 0

        for(int i = 0; i < str.Length; i++){
            if(Char.IsDigit(str[i]) || str[i] == 'N'){
                while(true){//TODO: need to check for fractional numbers, like 3.4
                    //System.Console.WriteLine("Looping here");
                    //System.Console.WriteLine("tempString at beginning of loop: tempstring = " + tempString);
                    
                    if(!Char.IsDigit(str[i])){//(3)-(2)
                        if(str[i] == 'N'){
                            tempString += str[i];
                        }

                        else if(str[i] == '.'){
                            tempString += str[i];
                        }

                        else{
                            listOfOperators.Add(str[i]);
                            listOfNumbers.Add(tempString);
                            //System.Console.WriteLine("tempString before break: tempstring = " + tempString);
                            tempString = String.Empty;
                            //i--;
                            break;
                        }
                    }

                    else{
                        tempString += str[i];
                    }

                    if(i == str.Length - 1){
                        listOfNumbers.Add(tempString);
                        //System.Console.WriteLine("tempString before break: tempstring = " + tempString);
                        tempString = String.Empty;
                        //i--;
                        break;
                    }

                    i++;
                }
            }
        }

        //need to replace N with minus sign so that calculations can be performed on the numbers. 
        //Methods at the bottom of this file run calculations on numbers
        for(int i = 0; i < listOfNumbers.Count; i++){
            if(listOfNumbers[i].Contains('N')){
                listOfNumbers[i] = listOfNumbers[i].Replace('N','-');
            }
        }

        /*
        System.Console.WriteLine();
        System.Console.WriteLine("listOfNumbers content: ");
        for(int i = 0; i < listOfNumbers.Count; i++){
            System.Console.Write("Entry " + i + ": " + listOfNumbers[i] + " , ");
        }

        System.Console.WriteLine();
        System.Console.WriteLine("listOfOperators content: ");
        for(int i = 0; i < listOfOperators.Count; i++){
            System.Console.Write("Entry " + i + ": " + listOfOperators[i] + " , ");
        }
        */

        //While loop below just handles the order of operations for the segment that is being calculated
        while(listOfOperators.Count > 0){
            if(listOfOperators.Contains('^')){
                for(int i = 0; i < listOfOperators.Count; i++){
                    if(listOfOperators[i] == '^'){
                        num = Exponentiate(double.Parse(listOfNumbers[i]), double.Parse(listOfNumbers[i + 1]));
                        listOfOperators.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.Insert(i, num.ToString());
                        break;
                    }
                }
            }

            else if(listOfOperators.Contains('*') || listOfOperators.Contains('/')){
                for(int i = 0; i < listOfOperators.Count; i++){
                    if(listOfOperators[i] == '/'){
                        num = FindQuotient(double.Parse(listOfNumbers[i]), double.Parse(listOfNumbers[i + 1]));
                        listOfOperators.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.Insert(i, num.ToString());
                        break;
                    }

                    else if(listOfOperators[i] == '*'){
                        num = FindProduct(double.Parse(listOfNumbers[i]), double.Parse(listOfNumbers[i + 1]));
                        listOfOperators.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.Insert(i, num.ToString());
                        break;
                    }
                }
            }

            else if(listOfOperators.Contains('+') || listOfOperators.Contains('-')){
                for(int i = 0; i < listOfOperators.Count; i++){
                    if(listOfOperators[i] == '+'){
                        num = FindSum(double.Parse(listOfNumbers[i]), double.Parse(listOfNumbers[i + 1]));
                        listOfOperators.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.Insert(i, num.ToString());
                        break;
                    }

                    else if(listOfOperators[i] == '-'){
                        num = FindDifference(double.Parse(listOfNumbers[i]), double.Parse(listOfNumbers[i + 1]));
                        listOfOperators.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.RemoveAt(i);
                        listOfNumbers.Insert(i, num.ToString());
                        break;
                    }
                }
            }
        }
        //System.Console.WriteLine("Before if listOfNumbers[0] = " + listOfNumbers[0]);

        //insert N to indicate negative number. This is how I figured out how to handle negative numbers. See NegativeNumbersHandler.cs
        if(listOfNumbers[0].Contains('-')){
            listOfNumbers[0] = listOfNumbers[0].Remove(0, 1).Insert(0, "N");
        }

        //System.Console.WriteLine("After if listOfNumbers[0] = " + listOfNumbers[0]);

        result = listOfNumbers[0];
		return result;
	}

    private double FindSum(double num1, double num2){
        return num1 + num2;
    }

    private double FindDifference(double num1, double num2){
        return num1 - num2;
    }

    private double FindQuotient(double num1, double num2){
        return num1 / num2;
    }

    private double FindProduct(double num1, double num2){
        return num1 * num2;
    }

    private double Exponentiate(double num1, double num2){
        return Math.Pow(num1, num2);
    }
}
