
using System;
using pompom.Data;
using pompom.Models;
using Xamarin.Forms;

namespace pompom
{
    public partial class ThisWeeksMessageDetailPage : ContentPage, ICommentAdded
    {
        public Message Message { get; private set; }
        public ThisWeeksMessageDetailPage(Message message)
        {
            InitializeComponent();
            this.Message = message;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

           Profile messageProfile = await App.Data.GetProfileByIdAsync(Message.Id);
           nameLabel.BindingContext = messageProfile;
           messageLabel.BindingContext = Message;
           likesCountLabel.BindingContext = Message;
           UpdateInfo();
        }

        public async void UpdateInfo()
        {
            bool hasComments = Message.Commentaries.Count == 0;
            noCommentsView.IsVisible = hasComments;
            etCommentContainer.IsVisible = !hasComments;
            foreach (Message commentMessage in Message.Commentaries)
            {
                Profile messageProfile = await App.Data.GetProfileByIdAsync(commentMessage.ProfileId);
                System.Diagnostics.Debug.WriteLine("comment id = " + commentMessage.Id);
                CommentMessageView childView = new CommentMessageView(commentMessage, messageProfile);
                childView.ICommentAdded = this;
                slInsertCommentsHere.Children.Add(childView);
            }
        }


        public void OnLikeClicked(object sender)
        {            
            Message.LikeOrUnlikeBy(TestData.GetCurrentUserId());
        }

        public void OnNoCommentsClicked(object sender)
        {
            noCommentsView.IsVisible = false;
            etCommentContainer.IsVisible = true;
        }

        async void CommentEntered(object sender, System.EventArgs e)
        {
            var text = ((Entry)sender).Text;
            ((Entry)sender).Text = "";
            Message comment = new Message(TestData.GetCurrentUserId(), text, Message.Id);
            Message.AddComment(comment);
            Profile currentProfile = await App.Data.GetProfileByIdAsync(TestData.GetCurrentUserId());
            slInsertCommentsHere.Children.Add(new CommentMessageView(comment, currentProfile));
        }

        void ICommentAdded.OnCommentAdded(Message message, Profile profile)
        {
            Message.AddComment(message);
            CommentMessageView childView = new CommentMessageView(message, profile);
            childView.ICommentAdded = this;
            slInsertCommentsHere.Children.Add(childView);
        }
    }
}
