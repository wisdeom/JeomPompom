﻿using System.Collections.Generic;
using System.Threading.Tasks;
using pompom.Models;
using System.Linq;
using System.IO;

namespace pompom.Data
{
    public class TestData : IData
    {
        public async Task<IList<Profile>> GetWeeksPeopleAsync()
        {
            // Emulate network delay.
            await Task.Delay(500);

            return GetWeeksPeople();
        }

        private List<Profile> GetWeeksPeople()
        {
            var list = new List<Profile>();
            var Daniel = GetDaniel();
            var Yura = GetYura();
            var Meirav = GetMeirav();
            list.Add(Daniel);
            list.Add(Yura);
            list.Add(Meirav);
            return list;
        }

        public async Task<IList<DetailProfile>> GetDetailProfile(){
            await Task.Delay(50);

            var list = new List<DetailProfile>();
            var Daniel = new DetailProfile("Daniel", "Adams", "+1 555 555 0798", true, "avatar-placeholder.png", "I'm here");
			var Yura = new DetailProfile("Yura", "Lee", "+1 555 546 0798", true, "avatar-placeholder.png", "Online now");
            var Meirav = new DetailProfile("Meirav", "Feiler", "+1 555 234 5432", false, "avatar-placeholder.png", "Busy");
			list.Add(Daniel);
			list.Add(Yura);
			list.Add(Meirav);
            return list;
        }

        public async Task<DetailProfile> GetUserProfile(){
            await Task.Delay(50);

            var list = new DetailProfile("", "", "", false, "avatar-placeholder.png", "Online");

			//var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return list;
        }

        //Follow up is for mockup purposes, to use both in Profiles and This Week's People's lists.
        private Profile GetDaniel()
        {
            return new Profile(0, "Daniel", "Adams", "Program Manager", "Dan", "v-daada", "Don't wait, do it now."); 
        }

        private Profile GetYura()
        {
            return new Profile(1, "Yura", "Lee", "Business support", "yura", "a-yura", ": - )");
        }

        private Profile GetMeirav()
        {
            return new Profile(2, "Meirav", "Feiler", "Software Engineer 2", "Meirav", "mefeiler", "go go go");
        }
        public async Task<IList<Message>> GetThisWeeksList()
        {

            // Emulate network delay
            await Task.Delay(500);

            var list = new List<Message>();
            var danielId = GetDaniel().Id;
            var yuraId = GetYura().Id;
            var meiravId = GetMeirav().Id;

            Message danielMessage = new Message(danielId, "Lorem ipsum dolor sit amet, insolens menandri consectetuer eam ad. Cu modus saperet vim. An est dictas reprehendunt. Enim postulant ea usu, at facete vidisse eam, quo etiam audire ut. Sit et justo assentior, vel ad erant luptatum.");
            danielMessage.Commentaries.Add(new Message(yuraId, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus."));
            danielMessage.Commentaries.Add(new Message(meiravId, "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus."));
            danielMessage.Commentaries.Add(new Message(meiravId, "Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus."));
            list.Add(danielMessage);
            list.Add(new Message(yuraId, "Vis affert concludaturque ex, facer utinam civibus quo at, delectus gloriatur scriptorem per eu. Mollis delectus sententiae vim cu, pri ne omnesque mandamus."));
            list.Add(new Message(danielId, "Munere consequuntur his an. Te sea minim dolor quaeque. Et audiam aperiam mei. Tota graece constituto sed eu, ea modus everti concludaturque pri, idque dicta utamur mei cu. Ex nullam erroribus per."));
            Message lastMessage = new Message(meiravId, " Id esse nostrud scriptorem vel, mea nibh case ut. Debet alienum vulputate ad sit.");
            lastMessage.Liked.Add(yuraId);
            lastMessage.Liked.Add(danielId);
            lastMessage.Liked.Add(meiravId);
            list.Add(lastMessage);
            return list;
        }

        public async Task<Profile> GetProfileByIdAsync(int id)
        {
            //Mocking server response. 
            await Task.Delay(500);
            return GetWeeksPeople().FirstOrDefault(i => i.Id == id);
        }

        public static int GetCurrentUserId()
        {
            //mockuped yet
            return 1;
        }

        public static Channel GetMockupChannel()
        {
            Channel channel = new Channel(1, "#general");
            List<int> participants = new List<int>(new int[]{ 1, 2, 3 });
            channel.AddParticipants(participants);
            return channel;
        }
    }
}
