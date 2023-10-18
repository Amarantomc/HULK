using System.Text.RegularExpressions;
using HULK;
public static class PI{
      public static bool PICheck(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" PI ") != -1;
  } 
  public static string pi(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    int a=s.IndexOf(" PI ");
    if(a==-1){
        Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,4,"Missing PI"));
        return " ;";
    } else{
   text=text.Remove(a,2);
   text= text.Insert(a,Math.PI.ToString());
    return text;
    }
 
  }
}