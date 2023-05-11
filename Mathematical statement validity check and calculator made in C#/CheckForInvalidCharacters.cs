using System.Globalization;
//I named this class before I understood the full extent of what it would contain.
public class CheckCharacterValidity{
    public bool CheckValidity(string? str){
        int num = 0;
        string numString;

        if(str == String.Empty || !str!.Any(Char.IsDigit)){//checks to see if it is empty or doesn't contain a single integer.
            return false;//if either of those conditions are met, then that is not a valid input.
        }

        else if(str![0] == '.' || str[str.Length - 1] == '.'){
            return false;
        }

        for(int i = 0; i < str?.Length; i++){
            if(str[i] != '(' && str[i] != ')' && str[i] != '^' && str[i] != '*' && str[i] != '/' && str[i] != '-' && str[i] != '+' 
            && !Char.IsNumber(str[i])){//This checks to see if there are any invalid characters
                return false;
            }

            else if((i != 0 && i != str.Length - 1) && (str[i] == '+' || str[i] == '-' || str[i] == '+' || str[i] == '/'
            || str[i] == '*' || str[i] == '^')){//check operator validity; mostly checking adjacent characters
                if(!DetermineOperatorValidity(str[i - 1], str[i], str[i + 1])){
                    return false;
                }
            }

            else if((i == 0 || i == str.Length - 1) && (str[i] == '+' || str[i] == '/' || str[i] == '*' || str[i] == '^' || str[i] == '-')){
                if(str[i] != '-'){//operators cannot begin or end an expression unless it is denoting negative value
                    return false;
                }

                else if(str[i] == '-' && i == str.Length - 1){
                    return false;
                }
            }

            else if(str[i] == '(' || str[i] == ')'){//() is erroneous, so check for them
                if(i == 0 && str[i] == '(' && str.Length >= 2 && str[i + 1] == ')'){
                    return false;
                }

                else if (i != str.Length - 1 && str[i] == '(' && str[i + 1] == ')'){
                    return false;
                }
            }

            //If character is a number, then see if that number that is in str is a valid double.
            else if(Char.IsNumber(str[i])){
                numString = String.Empty;

                while(Char.IsNumber(str[i]) || str[i] == '.'){//periods are valid here because of fractional numbers.
                    numString += str[i];
                    if(str[i] == '.' && i == str.Length){
                        return false;
                    }

                    else if(str[i] == '.' && i != str.Length && !Char.IsDigit(str[i + 1])){
                        return false;
                    }

                    if(i == str.Length - 1){//to prevent out of bounds exception
                        break;
                    }

                    i++;
                }

                try{//Need to see if it can actually parse, because numString could contain things like 3..2, which is invalid.
                    double.Parse(numString);
                }

                catch(Exception){
                    return false;
                }

                //below prevents infinite loop if last char in str is a number
                if(i != str.Length - 1 || !Char.IsNumber(str[i])){
                    i--;
                }
            }

            if(str[i] == '('){//For each open parenthesis increase num by one
                num++;
            }

            else if(str[i] == ')'){//For each closing parenthesis decrease num by one
                num--;
            }

            if(num < 0){//If num is ever -1, then user did not use parenthesis correctly
                return false;
            }
        }

        if(num > 0){//If num is ever greater than zero, then user did not use parenthesis correctly
            return false;
        }

        return true;
    }

    //The method below can likely be refactored some, I will test it later.
    private bool DetermineOperatorValidity(char previousCharacter, char currentCharacter, char nextCharacter){
        string operators = "+-*/^";

        if(operators.Contains(previousCharacter) || operators.Contains(nextCharacter)){
            if(currentCharacter == '-' && previousCharacter == '^' && !operators.Contains(nextCharacter)){
                return true;
            }

            else if(currentCharacter == '^' && nextCharacter == '-' && !operators.Contains(previousCharacter)){
                return true;
            }

            else{
                return false;
            }
        }

        else if(currentCharacter != '-' && ((previousCharacter == '(' && nextCharacter == '(') || (previousCharacter == ')' && nextCharacter == ')') || 
        (previousCharacter == '(' && nextCharacter == ')'))){
            return false;
        }

        else if(currentCharacter != '-' && previousCharacter == '(' || nextCharacter == ')'){
            return false;
        }

        else if((previousCharacter == '(' && currentCharacter == ')') || (nextCharacter == ')' && currentCharacter == '(')){
            return false;
        }

        return true;
    }
}