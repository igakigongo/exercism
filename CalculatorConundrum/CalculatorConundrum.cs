namespace CalculatorConundrum;

using static SimpleOperation;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
        => operation switch
        {
            "+" => FormatResult(operand1, operand2, operation, Addition),
            "*" => FormatResult(operand1, operand2, operation, Multiplication),
            "/" => FormatResult(operand1, operand2, operation, Division),
            "" => throw new ArgumentException("", nameof(operation)),
            null => throw new ArgumentNullException(nameof(operation)),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };

    private static string FormatResult(int operand1, int operand2, string op,
        Func<int, int, int> func) =>
        op == "/" && operand2 == 0
            ? "Division by zero is not allowed."
            : $"{operand1} {op} {operand2} = {func(operand1, operand2)}";
}
