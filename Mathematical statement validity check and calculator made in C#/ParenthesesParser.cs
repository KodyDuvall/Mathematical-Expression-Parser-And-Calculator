public class ParenthesesParser{
    public string ParseParentheses(string str){
		int position = 0;
        int beginningPosition;
        int endingPosition;
		string numString;
		string tempString;

        SegmentCalculator segmentCalculator = new SegmentCalculator(); 
		/*This loop finds what is contained in the most nested parentheses and evaluates that first, decomposing from most nested
          to least nested. It will then send that segment off to be calculated and returned for reinsertion.  
        */
		while(str.Contains('(')){
			if(str[position] == '('){
                beginningPosition = position;
                tempString = String.Empty;

				while(true){
                    position++;
					if(str[position] != '(' && str[position] != ')'){
						tempString += str[position]; 
					}
					
					else if(str[position] == '('){
                        beginningPosition = position;
						tempString = String.Empty;
					}
					
					else if (str[position] == ')'){
                        endingPosition = position;
						numString = segmentCalculator.CalculateSegment(tempString);
                        str = HandleInsertion(str, beginningPosition, endingPosition, tempString.Length + 2, numString);
                        position = -1;
                        break;
					}
				}
			}
			
			position++;
		}

        if(str.Contains('+') || str.Contains('^') || str.Contains('*') || str.Contains('/') || str.Contains('-')){
            str = segmentCalculator.CalculateSegment(str);
        }

        if(str.Contains('N')){
            str = str.Replace('N', '-');
        }

		return str;
	}
    /*The method below handles the insertion process after each segment has ben calculated. It also I identifys what expressions are
      found outside of the segment that was just calculated in order to determine if that segment should be multipled, like in the
      event of 3([Calculated Segment]), where [Calculated Segment] would need to be multiplied by 3 when it is reinserted, and if 
      the segment is being multipled by negative 1, denoted by N (see NegativeNumbersHandler.cs for how that is accomplished)
    */
    private string HandleInsertion(string stringToChange, int beginningPosition, int endingPosition,
     int removeLength, string parsedParenthesisSegment){
        if(beginningPosition != 0){
            if(Char.IsDigit(stringToChange[beginningPosition - 1])){
                parsedParenthesisSegment = parsedParenthesisSegment.Insert(0, "*");
            }

            else if(stringToChange[beginningPosition - 1] == 'N'){
                if(parsedParenthesisSegment[0] == 'N'){
                    parsedParenthesisSegment = parsedParenthesisSegment.Remove(0,1);
                    beginningPosition--;//This and line below are magic to me lol. I was just trying stuff until it worked!
                    removeLength++;
                    //stringToChange.Remove(stringToChange[beginningPosition - 1], 1);
                }

                else{
                    parsedParenthesisSegment = parsedParenthesisSegment.Insert(0, "N");
                    beginningPosition--;//This and line below are magic to me lol. I was just trying stuff until it worked!
                    removeLength++;
                    //stringToChange.Remove(stringToChange[beginningPosition - 1], 1);
                }
            }
        }

        if(endingPosition != stringToChange.Length - 1){
            if(Char.IsDigit(stringToChange[endingPosition + 1])){
                //parsedParenthesisSegment = parsedParenthesisSegment.Insert(parsedParenthesisSegment.Length - 1, "*");
                parsedParenthesisSegment = parsedParenthesisSegment.Insert(parsedParenthesisSegment.Length, "*");
            }
        }

        return stringToChange.Remove(beginningPosition, removeLength).Insert(beginningPosition, parsedParenthesisSegment);
    }
}