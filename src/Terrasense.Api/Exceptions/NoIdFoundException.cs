public class NoIdFoundException : Exception
{
  public int id { get; set; }
  public NoIdFoundException(int id) : base("No ID found for the provided input.")
  {
    this.id = id;
  }
}
