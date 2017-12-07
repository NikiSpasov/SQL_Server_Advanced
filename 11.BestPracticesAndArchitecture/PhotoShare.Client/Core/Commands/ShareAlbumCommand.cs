namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(params string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }
            throw new NotImplementedException();
        }
    }
}
