﻿using System;
using System.Runtime.CompilerServices;

namespace AutoCSer.TestCase.ChatClient
{
    /// <summary>
    /// 群聊客户端
    /// </summary>
    internal sealed class Client : IDisposable
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        private string userName;
        /// <summary>
        /// 群聊客户端
        /// </summary>
        private ChatServer.TcpClient.Server.TcpOpenClient client;
        /// <summary>
        /// 当前客户端 TCP 套接字
        /// </summary>
        private AutoCSer.Net.TcpServer.ClientSocket socket;
        /// <summary>
        /// 获取用户信息 回调保持
        /// </summary>
        private AutoCSer.Net.TcpServer.KeepCallback getUserKeepCallback;
        /// <summary>
        /// 获取消息 回调保持
        /// </summary>
        private AutoCSer.Net.TcpServer.KeepCallback getMessageKeepCallback;
        /// <summary>
        /// 是否登录成功
        /// </summary>
        internal bool IsLogin { get; private set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        /// <param name="userName"></param>
        internal Client(string userName)
        {
            this.userName = userName;
            this.client = new ChatServer.TcpClient.Server.TcpOpenClient(null, (client, socket) =>
            {
                if (client.login(socket, userName))
                {
                    Console.WriteLine("CurrentUser : " + userName);
                    return IsLogin = true;
                }
                Console.WriteLine("Login Error : " + userName);
                return false;
            });
            this.client._TcpClient_.OnSetSocket((socket) =>
            {
                if (socket.IsSocketVersion(ref this.socket))
                {
                    getUserKeepCallback = client.getUser((user) =>
                    {
                        if (user.Type == Net.TcpServer.ReturnType.Success)
                        {
                            Console.WriteLine(user.Value.Type.ToString() + " + " + user.Value.Name);
                        }
                    });
                    getMessageKeepCallback = client.getMessage((message) =>
                    {
                        if (message.Type == Net.TcpServer.ReturnType.Success)
                        {
                            Console.WriteLine(message.Value.Time.toString() + " " + message.Value.User + " : " + message.Value.Content);
                        }
                    });
                    Send("Hello");
                }
            });
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (IsLogin)
            {
                IsLogin = false;
                client.logout();
            }
            if (client != null)
            {
                client.Dispose();
                client = null;
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息内容</param>
        [MethodImpl(AutoCSer.MethodImpl.AggressiveInlining)]
        internal void Send(string message)
        {
            if (IsLogin) client.send(message);
        }
    }
}
