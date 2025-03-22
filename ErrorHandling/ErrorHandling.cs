namespace ErrorHandling;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception("You need to implement this method.");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        return int.TryParse(input, out var result) ? result : null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using (disposableObject)
            throw new Exception();
    }
}