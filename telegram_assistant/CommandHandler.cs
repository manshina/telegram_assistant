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

            chat.NewChatMessageRecived += (message) => {
                if (commandRepository.HasPendingCommand())
                {
                    var command = commandRepository.Get();
                    var commandResult = command.ExecuteNext(message , commandRepository);
                    
                    chat.ChatMessageSent(commandResult);
                }
                else
                {
                    var commandName = RecognizeCommand(message);
                    if (commandName != null)
                    {
                        var command = commandFactory.CreateCommand(commandName, Storage);
                        var commandResult = command.Execute();
                        commandRepository.Add(command);
                        chat.ChatMessageSent(commandResult);

                    }
                }

            };
        }

        public string? RecognizeCommand(string message)
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
