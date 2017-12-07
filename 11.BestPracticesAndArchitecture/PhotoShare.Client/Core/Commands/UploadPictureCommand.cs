namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class UploadPictureCommand : ICommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        
        public string Execute(string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }
            return "I'm the UploadPictureCommand";
        }
    }
}
