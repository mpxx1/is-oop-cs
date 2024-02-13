namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Messenger;

// wrapper of Telegram for program
public class TelegramMessenger : Messenger
{
    // has an api
    // it must has an interface, but impl doesn't worth complexity [avoiding empty interface]
    private TelegramApi _telegramApi = new TelegramApi();

    // behavior of program
    public override string Name => "Telegram";
}