using System;

namespace UnitTestTalk.Workshop.Models.Events
{
    public class RegistrationEvent : BaseEvent
    {
        public RegistrationEvent()
        {
            Published = DateTime.UtcNow;
        }

        public string Username { get; set; }
    }
}