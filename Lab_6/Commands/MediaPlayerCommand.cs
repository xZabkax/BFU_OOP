namespace Lab_6;

public class MediaPlayerCommand : ICommand 
{
    public void Execute()
    {
        try
        {
            File.AppendAllText(Keyboard.OutputFilePath, "Media player launched\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Undo()
    {
        try
        {
            File.AppendAllText(Keyboard.OutputFilePath, "Media player closed\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}