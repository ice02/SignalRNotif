using Microsoft.AspNetCore.SignalR;
using SignalRNotif.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRNotif.Core.Service.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("New connection with Id=" + Context.ConnectionId);

            var message = new NotificationMessage
            {
                Subject = "New service connection",
                Body = $"There is a new connection from the UserId:{Context.ConnectionId}",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information
            };

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"Disconnection Id={Context.ConnectionId}");

            var message = new NotificationMessage
            {
                Subject = "New service desconnection",
                Body = $"There is a desconnection from the UserId:{Context.ConnectionId}",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information,
                UriImage = "http://www.tampabay.com/resources/images/dti/rendered/2015/04/wek_plug041615_15029753_8col.jpg"
            };

            //await Clients.Caller.ProcessMessage(message);
            Clients.Others.ProcessMessage(message);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            
            var message = new NotificationMessage
            {
                Subject = "Group connection",
                Body = $"{Context.ConnectionId} has joined the group {groupName}.",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information,
                UriImage = "http://www.tampabay.com/resources/images/dti/rendered/2015/04/wek_plug041615_15029753_8col.jpg"
            };

            await Clients.Group(groupName).ProcessMessage(message);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            var message = new NotificationMessage
            {
                Subject = "Group connection",
                Body = $"{Context.ConnectionId} has left the group {groupName}.",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information
            };

            await Clients.Group(groupName).ProcessMessage(message);
        }

        async public Task SendMessage(NotificationMessage message)
        {
            Console.WriteLine($"[{message.User}]: {message.Body}");

            //await Clients.User(message.User).ProcessMessage(message);

            //var user = uList.Where(o => o.UserName == message.User);
            //if (user.Any())
            //{
            //    await Clients.Client(user.First().ConnectionID).ProcessMessage(message);//.sendMessage(sendFromId, userId, sendFromName, userName, message);
            //}

            await Clients.All.ProcessMessage(message);
        }

        //async public Task RegisterUser(UserInfo userInfo)
        //{
        //    if (userInfo == null) userInfo = new UserInfo { User = Context.ConnectionId, Group = string.Empty, Server = "Not Info Server" };

        //    var us = new UserConnection();
        //    us.UserName = userInfo.User; // Context.QueryString["username"];
        //    us.ConnectionID = Context.ConnectionId;
        //    uList.Add(us);

        //    //this.userInfo = userInfo;

        //    System.Threading.Thread.Sleep(2000);

        //    Console.WriteLine($"[User {userInfo.User} register at {DateTime.Now}] with id {Context.ConnectionId} ");

        //    var message = new NotificationMessage
        //    {
        //        Body = $"User {userInfo.User} conected at {DateTime.Now}",
        //        Subject = $"User {userInfo.User}",
        //        User = userInfo.User,
        //        MessageType = MessageType.Information,
        //        MessageDate = DateTime.Now,
        //        Group = userInfo.Group,
        //        Server = userInfo.Server,
        //        UriImage = "http://www.iconhot.com/icon/png/glossy/512/plug-5.png"
        //    };

        //    await Clients.Client(Context.ConnectionId).ProcessMessage(message);
        //}

    }

    public interface INotificationHub
    {
        //Task QuestionAdded(NotificationMessage question);
        //Task QuestionScoreChange(Guid questionId, int score);
        //Task AnswerCountChange(Guid questionId, int answerCount);
        //Task AnswerAdded(NotificationMessage answer);

        Task AddToGroup(string groupName);
        Task RemoveFromGroup(string groupName);
        Task ProcessMessage(NotificationMessage answer);
        //Task RegisterUser(UserInfo userInfo);
        Task NotificationMessageReceived(string username, NotificationMessage message);
    }
}
