using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;
using System.Runtime.CompilerServices;

int n = 0;

using Stream stream = System.IO.File.OpenRead("C:\\Users\\User\\Desktop\\SPOT ME BRO.mp4");
using Stream stream2 = System.IO.File.OpenRead("C:\\Users\\User\\Desktop\\гитхаб\\Pro_nas_-_A_bazy_dannyh_ya_lyublyu (mp3cut.net).mp3");

ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
{
        new KeyboardButton[] { "Хочу", "Не хочу" },
    })
{ ResizeKeyboard = true };

ReplyKeyboardMarkup replyKeyboardMarkup2 = new(new[]
{
        new KeyboardButton[] { "Да", "Нет" },
    })
{ ResizeKeyboard = true };

ReplyKeyboardMarkup replyKeyboardMarkup3 = new(new[]
{
        new KeyboardButton[] { "Ага", "Неа" },
    })
{
    ResizeKeyboard = true
};

ReplyKeyboardMarkup replyKeyboardMarkup4 = new(new[]
{
        new KeyboardButton[] { "Yes", "No" },
    })
{
    ResizeKeyboard = true
};

ReplyKeyboardMarkup replyKeyboardMarkup5 = new(new[]
{
        new KeyboardButton[] { "Очень", "Не люблю" },
    })
{
    ResizeKeyboard = true
};

ReplyKeyboardMarkup replyKeyboardMarkup6 = new(new[]
{
        new KeyboardButton[] { "Знаю", "Не знаю" },
    })
{
    ResizeKeyboard = true
};


var botClient = new TelegramBotClient("6653807062:AAHFdRpRjejvOpXNRcJrB1dU2D_-shc0Nhs");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");




Console.ReadLine();


// Send cancellation request to stop bot
cts.Cancel();




async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
   
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { } message)
        return;
    // Only process text messages
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
    n = n + 1;

    if (n==1) {
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Введите имя",
            cancellationToken: cts.Token);
        
    }


    if (n==2) 
    {   
        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Привет, " + messageText,
            cancellationToken: cancellationToken);

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Хочешь узнать, кто ты из преподавателей колледжа 'Царицыно'?",
            cancellationToken: cancellationToken);

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Выбери ответ",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }


    if (messageText == "Хочу")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты любишь базы данных?",
         replyMarkup: replyKeyboardMarkup2,
         cancellationToken: cancellationToken);

    }

    if (messageText == "Да")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Поздравляю! Ты - Смирнов Е. М.",
         replyMarkup: new ReplyKeyboardRemove(),
         cancellationToken: cancellationToken);


        await botClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromUri("https://disk.yandex.ru/i/UbYKIS2X-KekTw"),
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);

        await botClient.SendAudioAsync(
            chatId: chatId,
            audio: InputFile.FromStream(stream2),
            cancellationToken: cancellationToken);

        //HandleUpdateAsync(botClient, update, cancellationToken);
    }

        if (messageText == "Не хочу")
         {
            await botClient.SendTextMessageAsync(
             chatId: chatId,
             text: "Пока!",
             replyMarkup: new ReplyKeyboardRemove(),
             cancellationToken: cancellationToken);

            await botClient.SendStickerAsync(
                chatId: chatId,
                sticker: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/sticker-fred.webp"),
                cancellationToken: cancellationToken);
        }

        if (messageText == "Нет") {
            await botClient.SendTextMessageAsync(
             chatId: chatId,
             text: "Ты любишь питонистов?",
             replyMarkup: replyKeyboardMarkup3,
             cancellationToken: cancellationToken);
         }

    if (messageText == "Неа")
    {

        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Ты - Ларионов Д. И.",
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);

        await botClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromUri("https://disk.yandex.ru/i/OtiEzTlQfp18dg"),
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);
    }

    if (messageText == "Ага")
    {

        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Ты любишь объяснять что-то студентам?",
                replyMarkup: replyKeyboardMarkup4,
                cancellationToken: cancellationToken);
    }

    if (messageText == "No")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты - Лутфулин Д. А.",
         replyMarkup: new ReplyKeyboardRemove(),
         cancellationToken: cancellationToken);

        Message photo1message = await botClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromUri("https://disk.yandex.ru/i/XDXSvMqlvkXeDg"),
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);
    }

    if (messageText == "Yes")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты любишь определители?",
         replyMarkup: replyKeyboardMarkup5,
         cancellationToken: cancellationToken);
    }

    if (messageText == "Очень")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты - Ефимова О. И.",
         replyMarkup: new ReplyKeyboardRemove(),
         cancellationToken: cancellationToken);

        Message photo1message = await botClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromUri("https://disk.yandex.ru/i/4C3ymEgURkooFA"),
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);

    }

    if (messageText == "Не люблю")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты знаешь годы правления Брежнева?",
         replyMarkup: replyKeyboardMarkup6,
         cancellationToken: cancellationToken);
    }

    if (messageText == "Знаю")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты - Калмыкова Е. И.",
         replyMarkup: new ReplyKeyboardRemove(),
         cancellationToken: cancellationToken);

        Message photo1message = await botClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromUri("https://disk.yandex.ru/i/FAXr-9yw9L7tOw"),
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);
    }

    if (messageText == "Не знаю")
    {
        await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "Ты - Журавлёв С. Ю. Дождись видео!",
         replyMarkup: new ReplyKeyboardRemove(),
         cancellationToken: cancellationToken);

       
    
        await botClient.SendVideoNoteAsync(
            chatId: chatId,
            videoNote: InputFile.FromStream(stream),
            cancellationToken: cancellationToken);

    }
    }





Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}



namespace bot
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }
}