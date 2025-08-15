namespace Lab_4;

public class ObservableForDataChanged : Observable<ObservableForDataChanged>
{
    private object _attribute1;
    private object _attribute2;
    
    public object Attribute1
    {
        get => _attribute1;
        set
        {
            _attribute1 = value;
            this.NotifyPropertyChanged(this, nameof(Attribute1));
        }
    }

    public object Attribute2
    {
        get => _attribute2;
        set
        {
            _attribute2 = value;
            this.NotifyPropertyChanged(this, nameof(Attribute2));
        }
    }
}