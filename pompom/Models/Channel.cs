/// <summary>
/// Channel is a group of conversators having a chat
/// </summary>

using System.Collections.Generic;
using System.ComponentModel;

namespace pompom.Models
{
    public class Channel : INotifyPropertyChanged
    {
        /// <summary>
        /// channel name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// id of this channel
        /// </summary>
        public int Id { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public List<int> Participants { get; private set; } = new List<int>();
        public List<Message> Chat { get; private set; } = new List<Message>();

        public Channel (int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }
        /// <summary>
        /// Adding a channel participant
        /// </summary>
        /// <param name="id">Participant's Id</param>
        public void AddParticipant(int id)
        {
            Participants.Add(id);
            OnPropertyChanged("Participants");
        }

        public void AddParticipants(List<int> ids)
        {
            Participants.AddRange(ids);
            OnPropertyChanged("Participants");
        }

        public void IncomingMessage(int id, string message)
        {
            Chat.Add(new Message(id, message));
            OnPropertyChanged("Chat");
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
