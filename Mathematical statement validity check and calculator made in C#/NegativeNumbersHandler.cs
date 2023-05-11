public class NegativeNumbersHandler{
    public string FindAndOrganizeNegativeNumbers(string str){
        for(int i = 0; i < str.Length; i++){
            if(str[i] == '-'){//it seems more efficient to first check if the character is -, then run all other checks.
                if(i == 0){//this also protects against out of bounds exceptions for other checks
                    str = str.Remove(i, 1).Insert(i, "N");
                }

                else if(str[i + 1] == '(' && str[i - 1] != ')' && !Char.IsDigit(str[i - 1])){
                    str = str.Remove(i, 1).Insert(i, "N");//so things like (-(3+4)) become (N(3+4))
                }

                else if(str[i - 1] == '^'){//special case for things like 4^-5 becoming 4^N5
                    str = str.Remove(i, 1).Insert(i, "N");
                }

                else if(Char.IsDigit(str[i + 1]) && !Char.IsDigit(str[i - 1]) && str[i - 1] != ')'){
                    str = str.Remove(i, 1).Insert(i, "N");
                }
            }
        }

        return str;
    }
}