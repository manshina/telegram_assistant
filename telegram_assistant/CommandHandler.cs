using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal class CommandHandler
    {
        public CommandHandler(IChat chat, IStorage Storage)
        {
            CommandFactory commandFactory = new CommandFactory();
            CommandRepository commandRepository = new CommandRepository();

            chat.NewChatMessageRecived += (chatMessage) => {
                if (commandRepository.HasPendingCommand(chatMessage.Chat.Id))
                {
                    var command = commandRepository.Get(chatMessage.Chat.Id);
                    var commandResult = command.ExecuteNext(chatMessage.Text, commandRepository , chatMessage.Chat.Id);
                    
                    chat.ChatMessageSent(commandResult, chatMessage);
                }
                else
                {
                    var commandName = RecognizeCommand(chatMessage.Text);
                    if (commandName != null)
                    {
                        var command = commandFactory.CreateCommand(commandName, Storage);
                        var commandResult = command.Execute();
                        commandRepository.Add(command, chatMessage.Chat.Id);
                        chat.ChatMessageSent(commandResult, chatMessage);

                    }
                    else
                    {
                        chat.ChatMessageSent("Enter value", chatMessage);
                    }
                }

            };
        }

        public string? RecognizeCommand(string? message)
        {
            string getCommand = "/get";
            string storeCommand = "/store";

            if ((message == getCommand) || (message == storeCommand)){
                return message;
            }
            return null;


            
        }
    }
}
