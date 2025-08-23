namespace Lab_6;

public class VolumeDownCommand : ICommand
{
    public void Execute()
    {
        try
        {
            File.AppendAllText(Keyboard.OutputFilePath, "Volume decreased +20%" + "\n");
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
            File.AppendAllText(Keyboard.OutputFilePath, "Volume increased +20%" + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}