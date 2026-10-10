namespace Project;

public class LightSwitch { 
    public bool IsOn { get; private set; }

    /// <summary>
    /// Get the number of times the switch has been toggled.
    /// </summary>
    public int Switches { get; private set; }

    public LightSwitch(bool initialState) {
        IsOn = initialState;
    }

    public void Toggle() {
        IsOn = !IsOn;
        Switches++;
    }
}
