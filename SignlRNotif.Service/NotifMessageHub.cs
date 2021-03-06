﻿using Microsoft.AspNet.SignalR;
using SignalRNotif.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRNotif.Service
{
    public class NotifMessageHub : Hub
    {
        List<UserConnection> uList = new List<UserConnection>();

        public override Task OnConnected()
        {
            Console.WriteLine("New connection with Id=" + Context.ConnectionId);

            var message = new NotificationMessage
            {
                Subject = "New service connection",
                Body = $"There is a new connection from the UserId:{Context.ConnectionId}",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information
            };

            return base.OnConnected();

            //await Clients.Caller.ProcessMessage(message);
            //await Clients.Others.ProcessMessage(message);
        }
        async public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine($"Disconnection Id={Context.ConnectionId}");

            var message = new NotificationMessage
            {
                Subject     = "New service desconnection",
                Body        = $"There is a desconnection from the UserId:{Context.ConnectionId}",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information,
                UriImage    = "http://www.tampabay.com/resources/images/dti/rendered/2015/04/wek_plug041615_15029753_8col.jpg"
            };

            //await Clients.Caller.ProcessMessage(message);
            await Clients.Others.ProcessMessage(message);

            await base.OnDisconnected(stopCalled);
        }

        async public Task SendMessage(NotificationMessage message)
        {
            Console.WriteLine($"[{message.User}]: {message.Body}");

            //await Clients.User(message.User).ProcessMessage(message);

            var user = uList.Where(o => o.UserName == message.User);
            if (user.Any())
            {
                await Clients.Client(user.First().ConnectionID).ProcessMessage(message);//.sendMessage(sendFromId, userId, sendFromName, userName, message);
            }

            //await Clients.All.ProcessMessage(message);
        }


        async public Task RegisterUser(UserInfo userInfo)
        {
            if (userInfo == null) userInfo = new UserInfo { User = Context.ConnectionId, Group = string.Empty, Server = "Not Info Server" };

            var us = new UserConnection();
            us.UserName = userInfo.User; // Context.QueryString["username"];
            us.ConnectionID = Context.ConnectionId;
            uList.Add(us);

            //this.userInfo = userInfo;

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine($"[User {userInfo.User} register at {DateTime.Now}] with id {Context.ConnectionId} ");

            var message = new NotificationMessage
            {
                Body = $"User {userInfo.User} conected at {DateTime.Now}",
                Subject = $"User {userInfo.User}",
                User = userInfo.User,
                MessageType = MessageType.Information,
                MessageDate = DateTime.Now,
                Group = userInfo.Group,
                Server = userInfo.Server,
                UriImage = "http://www.iconhot.com/icon/png/glossy/512/plug-5.png"
            };

            await Clients.Client(Context.ConnectionId).ProcessMessage(message);
        }

    }
}
