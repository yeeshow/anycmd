﻿
namespace Anycmd.Engine.Edi.Messages
{
    using Abstractions;
    using Events;
    using InOuts;

    /// <summary>
    /// 
    /// </summary>
    public sealed class NodeUpdatedEvent : DomainEvent
    {
        public NodeUpdatedEvent(IAcSession acSession, NodeBase source, INodeUpdateIo output)
            : base(acSession, source)
        {
            if (output == null)
            {
                throw new System.ArgumentNullException("output");
            }
            this.Output = output;
        }

        internal NodeUpdatedEvent(IAcSession acSession, NodeBase source, INodeUpdateIo input, bool isPrivate)
            : this(acSession, source, input)
        {
            this.IsPrivate = isPrivate;
        }

        public INodeUpdateIo Output { get; private set; }
        internal bool IsPrivate { get; private set; }
    }
}
