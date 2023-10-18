using System.Text.RegularExpressions;
using HULK;
public static class Cos{
     public static bool cosCheck(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" cos ") != -1;
  } 
   public static string cos(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    int f=s.IndexOf(" cos ");
    if(f==-1){
        Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,5,"Missing sin"));
        return " ;";
    }
        int a=text.IndexOf("(");
        int b=text.LastIndexOf(")");
        if(a==b){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,4,"Missing Parentesis"));
            return " ";
        }
        string c= text.Substring(a+1,b-a-1);
        if(cosCheck(c)||Sin.sinCheck(c)||PI.PICheck(c)||Let.let(c)||Regex.IsMatch(c,"0-9")){
         Parser.text=c+";";
        Parser.pos=0;
        Parser.currentChar=Parser.text[Parser.pos];
        Parser.currentToken=Parser.GetToken();
        double d=Parser.Result();
        d=Math.Cos(d);
        text=text.Remove(f,b+1);
        text=text.Insert(f,d.ToString());
        return text;
        } else Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+1,"Diferent types"));
        return " ;";
        
    }
   }
