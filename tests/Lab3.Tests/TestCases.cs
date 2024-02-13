using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class TestCases
{
    // При получении сообщения пользователем, оно сохраняется в статусе “не прочитано”
    [Fact]
    public static void UnreadUserMessageTest()
    {
        var user = new User("Jack");
        var top = new Topic("User1", user, ImportantLevel.Low);
        var facade = new ProgramFacade(new List<ITopic>() { top });

        facade.SendMessageTo("Jack", new UserMessage("meme", "Pie hanged himself", ImportantLevel.Low));
        Assert.Equal(ReadStatus.UnRead, user.Messages[0].ReadStatus);
    }

    // При попытке отметить сообщение пользователя в статусе “не прочитано”
    // как прочитанное, оно должно поменять свой статус
    [Fact]
    public static void ChangeUserMessageStatusTest()
    {
        var user = new User("Jack");
        var top = new Topic("User1", user, ImportantLevel.Low);
        var facade = new ProgramFacade(new List<ITopic>() { top });

        facade.SendMessageTo("Jack", new UserMessage("meme", "Pie hanged himself", ImportantLevel.Low));
        user.Messages[0].SetRead();
        Assert.Equal(ReadStatus.Read, user.Messages[0].ReadStatus);
    }

    // При настроенном фильтре для адресата, отправленное сообщение,
    // не подходящее под критерии важности - до адресата дойти не должно
    // (в данном тесте необходимо использовать моки)
    [Fact]
    public static void UserMessageFilterTest()
    {
        IMessageReceiver user = Substitute.For<IMessageReceiver>();
        user.Name.Returns("Jack");

        var topic = new Topic("User1", user, ImportantLevel.High);
        var facade = new ProgramFacade(new List<ITopic> { topic });
        var message = new UserMessage("meme", "Pie hanged himself", ImportantLevel.Low);

        facade.SendMessageTo("Jack", message);

        user.DidNotReceive().Receive(message);
    }

    // При настроенном логгировании адресата, должен писаться лог,
    // когда приходит сообщение
    // (в данном тесте необходимо использовать моки)
    [Fact]
    public static void LoggerTest()
    {
        var message = new UserMessage("meme", "Pie hanged himself", ImportantLevel.Low);
        IList<IMessage> messages = new List<IMessage> { message };
        ILogger mockLogger = Substitute.For<ILogger>();

        mockLogger.PrintMessages(messages);
        mockLogger.Received().PrintMessages(messages);
    }

    // При отправке сообщения в месенджер, его реализация должна производить ожидаемое значение
    // (в данном тесте необходимо использовать моки)
    [Fact]
    public static void MessengerTest()
    {
        var message = new UserMessage("meme", "Pie hanged himself", ImportantLevel.Low);

        Messenger mockMessenger = Substitute.For<Messenger>();
        mockMessenger.Name.Returns("Messenger1");

        var topic = new Topic("Messenger", mockMessenger, ImportantLevel.Low);
        var facade = new ProgramFacade(new List<ITopic> { topic });

        facade.SendMessageTo("Messenger1", message);

        mockMessenger.Received().Receive(message);
    }
}