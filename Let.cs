using System.Text.RegularExpressions;
namespace HULK;
static class Let{
    
   private static List<string> variables =new List<string>();
   private static List<string> valores=new List<string>();
    
  public static bool let(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" let ") != -1;
  }
   public static string letin(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    int pos=s.LastIndexOf(" let ");
    int a=s.IndexOf(" in ");
    if(a==-1){
      Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,pos+6,"Missing in"));
    } else{
     string arg=text.Substring(pos+4,a - pos - 4);
     string [] b=arg.Split(":");
      for(int i=0;i<b.Length;i++){
       if(b[i].Contains("=")){
         variables.Add(b[i].Substring(0, b[i].IndexOf("=")).Trim());  
        valores.Add(b[i].Substring(b[i].IndexOf("=") + 1).Trim());
       }  
        if(!variables.Any()|| variables[i]==""|| char.IsDigit(variables[i][0])){
       Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,a-2,"Missing variable"));
      } 
        if(!valores.Any()|| valores[i]==""){
       Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,a+1,"Missing value"));
       } 
       if(!b[i].Contains("=")){
          Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,a,"Missing ="));
       }  
       
    } 
     string body=text.Substring(a+3);
    string c=Regex.Replace(body, "[^_ÑñA-Za-z0-9]", " ");
    c=" "+c+" ";
    for(int i=0;i<variables.Count;i++){
        if(c.Contains(" "+variables[i]+" ")){
            int d=c.IndexOf(" "+variables[i]+" ");
            body=body.Remove(d,variables[i].Length);
            body=body.Insert(d,valores[i]);
        } else Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,a+3,"Diferent variable or missing"));
    }
 text=text.Remove(pos);
 text=text.Insert(pos,body);
    return text;
    }
    return " ;";
   }



 }