using System.Text.RegularExpressions;
namespace HULK;
public static class Function{
    private static List<string> variables =new List<string>();
   private static List<string> values=new List<string>();
   public static string id;
    
   private static string cuerpo;

       public static bool functionCheck(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" function ") != -1;
  } 
  
    public static void function(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9=>]", " ");
    s = " " + s + " ";
    int pos=s.IndexOf(" function ");
    int a=s.IndexOf(" => ");
    string name=text.Substring(pos+9,Math.Abs(a-pos-9));
    cuerpo=text.Substring(a+3,Math.Abs(text.Length-a-4));
    int b=name.IndexOf("(");
    int c=name.IndexOf(")");
    string test=name.Substring(0,b);
    id=test;
    string f=name.Substring(b+1,Math.Abs(c-b-1));
    string [] d= f.Split(":");
    for(int i=0;i<d.Length;i++){
      variables.Add(d[i]);
   
    } 
 } 

     public static void functionValue(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
     
    int a=text.IndexOf("(");
    string body=text.Substring(a+1,text.Length-a-3);
    string [] d=body.Split(":");
    for(int i=0;i<d.Length;i++){
    if(Cos.cosCheck(d[i])||Sin.sinCheck(d[i])||PI.PICheck(d[i])||Let.let(d[i])||Regex.IsMatch(d[i],"[0-9]")){
      Parser.text= d[i]+";";
        Parser.pos=0;
        Parser.currentChar=Parser.text[Parser.pos];
        Parser.currentToken=Parser.GetToken();
       double t=Parser.Result();
       values.Add(t.ToString());
         
        } else{
         Parser.ErrorList.Add(new Error(Error.ErrorType.Semantic,a+2,"Diferent types"));
          
        } 
    }
     } 
       public static string functionCall(){
    //  cuerpo = Regex.Replace(cuerpo, "[^_ÑñA-Za-z0-9/+ -*^()]", " ");
    // cuerpo = " " + cuerpo + " ";
     
    for(int i=0;i<values.Count;i++){
    if(cuerpo.Contains(variables[i])){
      while(cuerpo.Contains(variables[i])){
      int r=cuerpo.IndexOf(variables[i]);
      cuerpo=cuerpo.Remove(r,variables[i].Length);
      cuerpo=cuerpo.Insert(r,values[i]);
      }
   
        } else Parser.ErrorList.Add(new Error(Error.ErrorType.Syntax,7,"Diferent variable or missing"));
    } 
   
    return cuerpo;
       }
   
}