public class NullValueException : Exception
{
  public NullValueException() : base("One or more required values were null.")
  {
  }
}
