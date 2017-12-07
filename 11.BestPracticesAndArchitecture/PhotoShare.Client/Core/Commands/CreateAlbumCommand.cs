namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Models;

    public class CreateAlbumCommand : ICommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>

        public string Execute(params string[] data)
        {
            string albumTitle = data[0];
            string BgColor = data[1];
            ICollection<Tag> tags = 



            throw new NotImplementedException();
        }
    }
}
