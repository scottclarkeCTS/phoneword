namespace Phoneword
{
    //This uses the built-in IDialer function.
    public interface IDialer
    {
        //This is a boolean
        bool Dial(string number);
    }
}