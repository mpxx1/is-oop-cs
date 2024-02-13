namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Messenger;

// wrapper of Signal for program
public class SignalMessenger : Messenger
{
    // has an api
    // it must has an interface, but impl doesn't worth complexity [avoiding empty interface]
    private SignalApi _signalApi = new SignalApi();

    // behavior of program
    public override string Name => "Signal";
}