using HULK;
using System.Text.RegularExpressions;
static class Print{
    
     public static bool ParentesisBalanceados(string expresion) { 
    int contador = 0; 
    foreach (char c in expresion) { 
        if (c == '(') { 
            contador++; 
        } 
        else if (c == ')') { 
            contador--; 
        } 
          if (contador < 0) 
        { 
            return false; 
        } 
    } 

    return contador == 0; 
}

 
    
    
    
    public static bool printChek(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" print ") != -1;
  }
    public static string print (string text){
        if(text.Contains("'")){
        int a=text.IndexOf("'"); 
        int b=text.LastIndexOf("'");
         if(a==b){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Expected,text.Length-3,"Missing comillas"));
            return " ";
        } else{
            string test=text.Substring(a,b-a); 
            test=test+";";
            return test;
        }
        
       
        } else{
            int a=text.IndexOf("(");
            int b=text.LastIndexOf(")");
           string test= text.Substring(a+1,b-a-1);
           test=test+";";
           return test;
        }
    }

}