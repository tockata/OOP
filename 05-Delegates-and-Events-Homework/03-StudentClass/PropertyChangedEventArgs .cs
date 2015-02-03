using System;

public class PropertyChangedEventArgs : EventArgs
{
    private string propertyName;
    private dynamic oldValue;
    private dynamic newValue;

    public PropertyChangedEventArgs(string propName, dynamic oldValue, dynamic newValue)
    {
        this.PropertyName = propName;
        this.OldValue = oldValue;
        this.NewValue = newValue;
    }

    public string PropertyName
    {
        get { return this.propertyName; }
        set { this.propertyName = value; }
    }
    public dynamic OldValue
    {
        get { return this.oldValue; }
        set { this.oldValue = value; }
    }
    public dynamic NewValue
    {
        get { return this.newValue; }
        set { this.newValue = value; }
    }
}