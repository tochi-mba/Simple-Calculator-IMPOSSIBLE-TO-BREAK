
using System.Data;

static string AddNumber() 
{

    double inp;

    try
    {
        Console.Write("Enter a number:");

        string rawInp = Console.ReadLine();

        inp = Convert.ToDouble(rawInp);

        string equation = "";

        return Convert.ToString(inp);
    }
    catch (Exception e)
    {
        
        Console.WriteLine(e.Message + "(Try again)");
    }

    return AddNumber();

}

static string AddOperator()
{

    Console.Write("Enter an Operator or '=' to evaluate:");
    string inp = Console.ReadLine();

    while (inp != "*" && inp != "/" && inp != "+" && inp != "-" && inp != "=")
    {

        Console.WriteLine("Enter a valid operator!");
        Console.Write("Enter an Operator:");

        inp = Console.ReadLine();

    }
    
    return inp;

}

static string FilterEquation(string equation)
{
    
    string[] equationList = equation.Split(';');
    string filteredEquation = String.Join("", equationList);

    return filteredEquation.Replace("=", "");

}

static double EvaluateEquation(string equation)
{

    DataTable dt = new DataTable();
    double answer = Convert.ToDouble(dt.Compute(FilterEquation(equation), ""));

    return answer;

}

string equation = "";
bool finished = false;

while (!finished)
{

    string[] equationList = equation.Split(";");

    if (equation.Length == 0)
    {
        equation = AddNumber();

    }
    else if (equationList.Length % 2 != 0)
    {
        equation = equation + ';' + AddOperator();
    }
    else
    {
        equation = equation + ';' + AddNumber();
    }

    if (equation.Contains('='))
    {
        finished = true;
    }
    else
    {
        Console.WriteLine(FilterEquation(equation));
    }

}

Console.Write(FilterEquation(equation) + " = ");
Console.Write(EvaluateEquation(equation));