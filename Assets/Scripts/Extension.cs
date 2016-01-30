public static class Extension
{

  public static string F(this string s, params object[] objects)
  {
    return string.Format(s, objects);
  }
}
