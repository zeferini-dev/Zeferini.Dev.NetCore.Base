﻿namespace NetCore.Base.Model.Response.Errors
{
    public class ErrorResponse
    {
        public string Id { get; private set; }
        public string Parameter { get; private set; }
        public List<string> Messages { get; private set; }

        public ErrorResponse()
        {
        }

        public ErrorResponse(string id, string parameter)
        {
            if (Messages == null) { Messages = new List<string>(); }
            Id = id;
            Parameter = parameter;
        }

        public ErrorResponse(string id, string parameter, string message) : this(id, parameter)
        {
            if (Messages == null) { Messages = new List<string>(); }

            Id = id;
            Parameter = parameter;
            Messages.Add(message);
        }

        public void AddMessage(string message)
        {
            if (Messages == null) { Messages = new List<string>(); }

            Messages.Add(message);

        }
    }
}
