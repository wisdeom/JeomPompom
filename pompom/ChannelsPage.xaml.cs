using pompom.Data;
using pompom.Models;
using Xamarin.Forms;

namespace pompom
{
    public partial class ChannelsPage : ContentPage
    {
        public Channel Channel { get; private set; }
        public ChannelsPage(Channel channel)
        {
            InitializeComponent();
            this.Channel = channel;
        }

        public void OnMessageTyped (string message)
        {
            Channel.IncomingMessage( TestData.GetCurrentUserId(), message);
        }

        public void OnParticipantAdded(int id)
        {
            Channel.AddParticipant(id);
        }
    }


}