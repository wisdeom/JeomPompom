using System.Collections.Generic;
using System.ComponentModel;

namespace pompom.Models
{
    /// <summary>
    ///  A model for Posted message.
    /// </summary>

    public class Message : INotifyPropertyChanged
    {
        private const int INVALID_ID  = -1;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ProfileId { get; private set; }
        public string MessageFromePerson { get; private set; }
        /// <summary>
        /// List of id's of the users who liked it.
        /// </summary>
        public List<int> Liked { get; private set; } = new List<int>();
        //An id for the message.
        public int Id { get; private set; }
        /// <summary>
        /// Id of a message it is a commentary to.
        /// </summary>
        public int FollowsToMessageId { get; private set; } = INVALID_ID;
        public List<Message> Commentaries { get; private set; } = new List<Message>();
        /// <summary>
        /// This property is for Binding to XAML.
        /// </summary>
        public int LikesCount
        {
            get 
            {
                return Liked.Count;
            }        
        }
        
        public Message(int profileId, string messageFromePerson) 
        {
            this.ProfileId = profileId;
            this.MessageFromePerson = messageFromePerson;
        }

        public Message(int profileId, string messageFromePerson, int isCommentToMessageId) : this (profileId, messageFromePerson)
        {
            this.FollowsToMessageId = isCommentToMessageId;
        }

        public void AddComment(Message message)
        {
            this.Commentaries.Add(message);
            OnPropertyChanged("Commentaries");
        }

        public void LikeOrUnlikeBy(int profileId)
        {
            bool removed = false;
            for (int i = 0; i< Liked.Count; i++)
            {
                if (Liked[i] == profileId)
                {
                    Liked.RemoveAt(i);
                    removed = true;
                    break;
                }
            }

            if (!removed) Liked.Add(profileId);
            OnPropertyChanged("LikesCount");
            OnPropertyChanged("Liked");
        }

        public void IncomingCommentary(Message message)
        {
            Commentaries.Add(message);
        }

        protected void OnPropertyChanged(string name)
        {            
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
