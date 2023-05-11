Title of Project: Mathematical Expression Parser and Calculator

Reasons for making this project:
  I consider myself a novice at computer programming. I mainly created this project as a test of my knowledge of the fundamentals of programming logic. I am not very familiar with regular expressions, so I decided to make this project without using them. I want to learn how to properly use regular expressions, and I plan on remaking this project with usage of regular expression as a way of comparing the two projects and determining which I like more. 
  
Project Description: 
  This application is designed to take an input of a non-variable mathematical expression and parse it into a calculable form, and then display the final calculated result to the user. This application only supports the basic mathematical operators, namely: + - * / ^. This calculator cannot solve equations, and only accepts paraentheses, numbers (whole and non-whole), and the basic operators.
  
  The basic operators are defined as follows:
  + : This is the addition operator, and it is used to find the sum of two numbers.
  - : This is the subtraction operator, and it is used to find the difference of two numbers.
  / : This is the division operator, and it is used to find the quotient of two numbers.
  * : This is the multiplication operator, and it is used to find the product of two numbers.
  ^ : This is the exponential operator, and it is used to exponentiate one number with respect to another.

  Below are examples of acceptable inputs, with their associated outputs:
  Input: 3+5                        Output: 8
  Input: 3(5+1)                     Output: 18
  Input: 5+3*6/2                    Output: 14
  Input: 3((5*6)+3+(4*1))+2         Output: 113
  Input: -(-(4+(9-3^-(1+2))))-7     Output: 5.962962962962964
  
  Below are examples of unacceptable inputs, with their associated erroneous outputs:
  Input: 3++5           Output: Incorrect due to operator conflict. Improper usage of addition operator. 
  Input: 3(5+1          Output: Incorrect due to improper usage of parentheses. There is no closing parenthesis.
  Input: -/3+(3-8)      Output: Incorrect due to operator conflict. No number is defined on the left side of division operator.
  Input: 3+(5)+()       Output: Incorrect due to improper usage of parentheses. Parentheses cannot be empty.
  Input: x+4-9^7        Output: Incorrect due to invalid character. The character x is not a valid character for this calculator.
  Input: 3-2(+3)/(5+5)  Output: Incorrect due to operator conflict. There is no number on the left side of the first addition operator.
  
 How to use the project:
  The best way to use this project right now is to download the entire project folder as a zipped folder (it is very small), and you can either run the executable or open up your command line and navigate to the root directory of the extracted project. Then type:   dotnet run Program.cs   and that should result in the program starting. 
