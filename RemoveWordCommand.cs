using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class RemoveWordCommand : ICommand
    {
        public Comment comment;
        public string wordToRemove;
        public Forum forum;
        public RemoveWordCommand(Comment comment, string wordToRemove,Forum forum)
        {
            this.comment = comment;
            this.wordToRemove = wordToRemove;
            this.forum = forum;
        }

        public void Execute()
        {
            comment.RemoveWord(wordToRemove);
            forum.addComments(comment);
        }
    }

}
