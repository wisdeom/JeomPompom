using pompom.Data;
using pompom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace pompom
{
    public interface ICommentAdded
    {
        void OnCommentAdded(Message message, Profile profile);
    }
    public partial class CommentMessageView : ContentView
    {
        public ICommentAdded ICommentAdded { get; set; }
        public Message Message { get; private set; }
        public CommentMessageView(Message message, Profile messageProfile)
        {
            this.Message = message;
            InitializeComponent();
            nameLabel.BindingContext = messageProfile;
            messageLabel.BindingContext = message;
            likesCountLabel.BindingContext = message;

            bool hasComments = Message.Commentaries.Count == 0;
            noCommentsView.IsVisible = hasComments;
            etCommentContainer.IsVisible = !hasComments;
        }

        public void OnLikeClicked(object sender)
        {
            Message.LikeOrUnlikeBy(TestData.GetCurrentUserId());
        }

        async void CommentEntered(object sender, System.EventArgs e)
        {
            var text = ((Entry)sender).Text;
            ((Entry)sender).Text = "";
            Message comment = new Message(TestData.GetCurrentUserId(), text, Message.Id);
            Message.AddComment(comment);
            Profile currentProfile = await App.Data.GetProfileByIdAsync(TestData.GetCurrentUserId());
            ICommentAdded.OnCommentAdded(comment, currentProfile);
        }

        public void OnNoCommentsClicked(object sender)
        {
            noCommentsView.IsVisible = false;
            etCommentContainer.IsVisible = true;
        }
    }
}