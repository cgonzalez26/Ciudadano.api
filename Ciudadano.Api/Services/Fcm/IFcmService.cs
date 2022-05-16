using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Services.Fcm
{
    public interface IFcmService
    {
        Task<string> Subscribe(string topic, List<string> tokens);

        Task<string> Unsubscribe(string topic, List<string> tokens);

        Task<dynamic> Info(string token);

        Task<string> Send(FcmNotification fcmNotification);

        Task Send(List<string> topics, FcmNotification notification, bool includeMe);

        void SendOnNewThread(FcmNotification fcmNotification);
    }
}
