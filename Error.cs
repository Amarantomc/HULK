namespace HULK;
public class Error{
    public enum ErrorType{
        Expected,
        Syntax,
        Semantic,
        Unknow,
    } 
     public ErrorType errorType;
    public int ErrorPos;
    public string Argument; 
    
    public Error(ErrorType error,int ErrorPos, string Argument){
        this.ErrorPos=ErrorPos;
        this.errorType=error;
        this.Argument=Argument;
    } 
    public void ErrorShow(Error error){
        Console.WriteLine(error.errorType+" Error: "+error.Argument+" in pos "+error.ErrorPos);
    }
 

}