using System.Text.RegularExpressions;
using HULK;
public static class Sin{
  public static bool sinCheck(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" sin ") != -1;
  }
    public static string sin(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    int f=s.IndexOf(" sin ");
    if(f==-1){
        Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,5,"Missing sin"));
        return " ;";
    }
        int a=text.IndexOf("(");
        int b=text.IndexOf(")");
            if(a==-1||b==-1){
            if(a==-1){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,4,"Missing Parentesis"));
            } if(b==-1){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,text.Length,"Missing Parentesis"));
            }
           return " ";
        } 
        string c= text.Substring(a+1,b-a-1);
        if(Cos.cosCheck(c)||sinCheck(c)||PI.PICheck(c)||Let.let(c)||Regex.IsMatch(c,"[0-9]")){
        Parser.text=c+";";
        Parser.pos=0;
        Parser.currentChar=Parser.text[Parser.pos];
        Parser.currentToken=Parser.GetToken();
        double d=Parser.Result();
        d=Math.Sin(d);
        text=text.Remove(f,b+1);
        text=text.Insert(f,d.ToString());
        return text;
        } else Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+2,"Diferent types"));
        return " ;";
      
    }


}