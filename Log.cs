using System.Text.RegularExpressions;
namespace HULK;
public static class Log{
      public static bool logCheck(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" log ") != -1;
  } 
   public static string log(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    int f=s.IndexOf(" log ");
    double t=0;
    if(f==-1){
        Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,5,"Missing sin"));
        return " ;";
    } 
        int a=text.IndexOf("(");
        int b=text.LastIndexOf(")");
         if(a==-1||b==-1){
            if(a==-1){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,4,"Missing Parentesis"));
            } if(b==-1){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,text.Length,"Missing Parentesis"));
            }
           return " ";
        }
 
          string c= text.Substring(a+1,b-a-1);
          string []e=c.Split(":");
          int g=c.IndexOf(":");
          if(g==-1){
           Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,a+2,"Missing :"));
           return " ";
          } 
          if(e.Length!=2){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+2,"Missing arguments"));
            return " ";
          }
        if(Cos.cosCheck(e[0])||Sin.sinCheck(e[0])||PI.PICheck(e[0])||Let.let(e[0])||Regex.IsMatch(e[0],"[0-9]")){
      Parser.text= e[0]+";";
        Parser.pos=0;
        Parser.currentChar=Parser.text[Parser.pos];
        Parser.currentToken=Parser.GetToken();
       t=Parser.Result();
         
        } else{
         Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+2,"Diferent types"));
         return " ";
        } 
            
     if(Cos.cosCheck(e[1])||Sin.sinCheck(e[1])||PI.PICheck(e[1])||Let.let(e[1])||Regex.IsMatch(e[1],"[0-9]")){
      Parser.text= e[1]+";";
        Parser.pos=0;
        Parser.currentChar=Parser.text[Parser.pos];
        Parser.currentToken=Parser.GetToken();
        double d=Parser.Result();
        d=Math.Log(t,d);
        text=text.Remove(f,b+1);
        text=text.Insert(f,d.ToString());
        } else Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+2,"Diferent types"));
         if(text=="NaN;"){
          Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+2,"Invalid Arguments"));
         }
         if(Parser.ErrorList.Any()) return ";";
         return text;
          
          
   }
}